using System.Collections.Generic;
using System.Threading;

namespace $ext_specifiedsolutionname$.Application.Interfaces.Services
{
	public interface IService
	{
		List<bool> Get(CancellationToken cancellationToken);
	}
}