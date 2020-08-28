using $ext_specifiedsolutionname$.Application.Domain.Queries.SampleQuery.V1;
using System;
using System.Collections.Generic;

namespace $ext_specifiedsolutionname$.Application.Interfaces.Databases
{
	public interface IRepository
	{
		List<SampleDtoV1> Get();
	}
}