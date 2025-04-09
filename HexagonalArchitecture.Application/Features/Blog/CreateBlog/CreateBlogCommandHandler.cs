using HexagonalArchitecture.Shared;

namespace HexagonalArchitecture.Application.Features.Blog.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand , Result<BlogModel>>
{
	private readonly IBlogPort _blogPort;

	public CreateBlogCommandHandler(IBlogPort blogPort)
	{
		_blogPort = blogPort;
	}

	#region Handle

	public async Task<Result<BlogModel>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		if(request.requestModel.BlogTitle.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Title cannot be empty.");
			goto result;
		}

		if(request.requestModel.BlogAuthor.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Author cannot be empty.");
			goto result;
		}
		if (request.requestModel.BlogAuthor.IsNullOrEmpty())
		{
			result = Result<BlogModel>.Fail("Blog Content cannot be empty.");
			goto result;
		}

		result = await _blogPort.CreateBlogAsync(request.requestModel, cancellationToken);

	result:
		return result;

	}

	#endregion

}
