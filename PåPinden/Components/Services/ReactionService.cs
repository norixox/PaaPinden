using Microsoft.EntityFrameworkCore;
using PåPinden.Components.Data;
using PåPinden.Components.Models;

namespace PåPinden.Components.Services
{
    public class ReactionService
    {
        private readonly PaaPindenDbContext _db;

        public ReactionService(PaaPindenDbContext db)
        {
            _db = db;
        }

        public async Task LikePostAsync(string userId, Guid postId)
        {
            //har brugeren allerede har liket opslaget?
            var existingLike = await _db.Reactions
                .FirstOrDefaultAsync(r => r.UserId == userId && r.PostId == postId && r.Type == ReactionType.Like);

            if (existingLike == null)
            {
                var like = new Reaction
                {
                    UserId = userId,
                    PostId = postId,
                    Type = ReactionType.Like,
                    Date = DateTime.Now
                };
                _db.Reactions.Add(like);
            }
            else
            {
                _db.Reactions.Remove(existingLike);
            }

            await _db.SaveChangesAsync();
        }

        public async Task AddCommentAsync(string userId, Guid postId, string text)
        {
            var comment = new Reaction
            {
                UserId = userId,
                PostId = postId,
                Type = ReactionType.Comment,
                Text = text,
                Date = DateTime.Now
            };

            _db.Reactions.Add(comment);
            await _db.SaveChangesAsync();
        }

        // 3. DEL (Share)
        public async Task SharePostAsync(string userId, Guid postId)
        {
            var share = new Reaction
            {
                UserId = userId,
                PostId = postId,
                Type = ReactionType.Share,
                Date = DateTime.Now
            };

            _db.Reactions.Add(share);
            await _db.SaveChangesAsync();
        }

        // 4. GEM (Save)
        public async Task SavePostAsync(string userId, Guid postId)
        {
            var existingSave = await _db.Reactions
                .FirstOrDefaultAsync(r => r.UserId == userId && r.PostId == postId && r.Type == ReactionType.Save);

            if (existingSave == null)
            {
                var save = new Reaction
                {
                    UserId = userId,
                    PostId = postId,
                    Type = ReactionType.Save,
                    Date = DateTime.Now
                };
                _db.Reactions.Add(save);
                await _db.SaveChangesAsync();
            }
        }


        public async Task<List<Reaction>> GetNotificationsAsync(string userId)
        {
            return await _db.Reactions
                .Include(r => r.Post) //inkluder opslaget for at tjekke ejeren
                .Include(r => r.User) //Inkluder brugeren for at se hvem der har reageret
                .Where(r => r.Post.Owner!.Id == userId && r.UserId != userId)//Reaktioner på egne opslag, ikke ens egne
                .OrderByDescending(r => r.Date)
                .Take(20)
                .ToListAsync();
        }

        
        public async Task<int> GetLikeCountAsync(Guid postId)
        {
            return await _db.Reactions
                .CountAsync(r => r.PostId == postId && r.Type == ReactionType.Like);
        }
    }
}