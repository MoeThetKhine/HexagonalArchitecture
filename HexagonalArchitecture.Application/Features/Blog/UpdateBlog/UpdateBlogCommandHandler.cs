namespace HexagonalArchitecture.Application.Features.Blog.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<BlogModel>>
{
	private readonly IBlogPort _blogPort;

	public UpdateBlogCommandHandler(IBlogPort blogPort)
	{
		_blogPort = blogPort;
	}

	public async Task<Result<BlogModel>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;


		if (request.requestModel.BlogTitle.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Title cannot be empty.");
			goto result;
		}

		if (request.requestModel.BlogAuthor.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Author cannot be empty.");
			goto result;
		}

		if (request.requestModel.BlogContent.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Content cannot be empty.");
			goto result;
		}


		result = await _blogPort.UpdateBlogAsync(request.BlogId, request.requestModel, cancellationToken);

	result:
		return result;
	}

}
