namespace SaplingStore.DTOs.Image;

using Abstract;

public class ImageCreateDto: CreateDto,IFormFile{
    public IFormFile File { get; set; }
    public Stream OpenReadStream() => throw new NotImplementedException();
    public void CopyTo(Stream target) {
        throw new NotImplementedException();
    }
    public Task CopyToAsync(Stream target, CancellationToken cancellationToken = new CancellationToken()) => throw new NotImplementedException();
    public string ContentType { get; }
    public string ContentDisposition { get; }
    public IHeaderDictionary Headers { get; }
    public long Length { get; }
    public string FileName { get; }
}