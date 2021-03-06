﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using NUnit.Framework;

namespace Nest.Tests.Unit.ObjectInitializer.Repository
{
	[TestFixture]
	public class DeleteRepositoryRequestTests : BaseJsonTests
	{
		private readonly IElasticsearchResponse _status;

		public DeleteRepositoryRequestTests()
		{
			var request = new DeleteRepositoryRequest("my-repository");
			var response = this._client.DeleteRepository(request);
			this._status = response.ConnectionStatus;
		}

		[Test]
		public void Url()
		{
			this._status.RequestUrl.Should().EndWith("/_snapshot/my-repository");
			this._status.RequestMethod.Should().Be("DELETE");
		}
	}

}
