//
// AsyncTests.HttpClientTests.Addin.ExtensionTestRunner
//
// Authors:
//      Martin Baulig (martin.baulig@gmail.com)
//
// Copyright 2012 Xamarin Inc. (http://www.xamarin.com)
//
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Net.Http;

namespace AsyncTests.HttpClientTests.Addin {

	using Framework;

	public class ExtensionTestRunner : ITestRunner {
		IHttpClientHandler extension;

		public ExtensionTestRunner (IHttpClientHandler extension)
		{
			this.extension = extension;
		}

		#region ITestFixtureRunner implementation
		public TestContext CreateContext (TestFixture fixture)
		{
			var instance = Activator.CreateInstance (fixture.Type);
			var context = new HttpClientTestContext (fixture, instance);
			context.Handler = extension.CreateHandler ();
			context.Client = new HttpClient (context.Handler, true);
			return context;
		}

		public bool IsEnabled (TestCase test)
		{
			var attr = test.Attribute as HttpClientTestAttribute;
			if (attr == null)
				return false;
			return (attr.Target & HttpClientTestTarget.Custom) != 0;
		}

		public string Name {
			get { return extension.Name; }
		}
		#endregion
	}
}
