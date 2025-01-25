using AutoMapper;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.Models;

namespace SaplingStore.Repository;

public class SaplingRepository:ClassRepository<Sapling>
{
    public SaplingRepository(AppDbContext context, IMapper mapping) : base(context, mapping)
    {
    }
}