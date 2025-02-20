using Microsoft.EntityFrameworkCore;
using SaplingStore.Data;
using SaplingStore.Models;
using System.Linq;

namespace SaplingStore.Tests {
using Abstract;
using AutoMapper;

public class FakeClassRepository<TEntity>(AppDbContext context, IMapper mapper)
    : ClassRepository<TEntity>(context, mapper) where TEntity : Entity {
    protected override IQueryable<TEntity> GetQueryAbleObject() {
        return _context.Set<TEntity>().AsQueryable();
    }


}
}