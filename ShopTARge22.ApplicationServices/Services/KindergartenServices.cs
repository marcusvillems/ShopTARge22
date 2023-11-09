using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.Domain;


namespace ShopTARge22.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopTARge22Context _context;

        public DbContext DbContext { get; }

        public KindergartenServices 
            (ShopTARge22Context context)
        {
            _context = context;
        }


        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.CreatedAt = dto.CreatedAt;
            kindergarten.UpdatedAt = dto.UpdatedAt;

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> DetailsAsync(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            Kindergarten kindergarten = new Kindergarten();
            {
                kindergarten.Id = dto.Id;
                kindergarten.GroupName = dto.GroupName;
                kindergarten.ChildrenCount = dto.ChildrenCount;
                kindergarten.KindergartenName = dto.KindergartenName;
                kindergarten.Teacher = dto.Teacher;
                kindergarten.CreatedAt = dto.CreatedAt;
                kindergarten.UpdatedAt= dto.UpdatedAt;

                _context.Kindergartens.Update(kindergarten);
                await _context.SaveChangesAsync();
                return kindergarten;
            }
        }
        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergartenId = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Kindergartens.Remove(kindergartenId);
            await _context.SaveChangesAsync();
            return kindergartenId;
        }


    }
}
