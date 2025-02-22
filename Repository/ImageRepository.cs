namespace SaplingStore.Repository;

using Abstract;
using AutoMapper;
using Data;
using DTOs.Image;
using Helpers;
using Interfaces;
using Models;

public class ImageRepository:ClassRepository<Image> {
    public ImageRepository(AppDbContext context, IMapper mapping) : base(context, mapping) {
    }
    public override Type GetCreateDto() => typeof(ImageCreateDto);
    public override IQueryable<Image> GetQueryAbleObject() { return _context.Images.AsQueryable(); }
}

