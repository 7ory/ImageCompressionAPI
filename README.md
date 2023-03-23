# ImageCompressionAPI

I developed this API in order to resolv the problem i had where i had a ton files(PDFs) sitting on a Azure blog taking up too much space there, thus costing more money
since i constantly had to scale out. So i need a way to reduce the size of the files sitting on the blog and the newly generated oned

*Below is how the API works:*
- It firsts goes to the specified directory where the PDF files are store
- Pulls those files by looping through the list then coversts their format into a JPEG
- Before the JPEG files get saved to the directory, the pixed sizes on each is reduces while still maaintainin the picture quality
- After the pixels of the JPEGs are reduced the file size of the JPEG becomes small as wel then they are converted back to PDF formart then stored back to th desired
directory

Tools used:
- [Magick.NET](https://github.com/dlemstra/Magick.NET) for changing file formats
