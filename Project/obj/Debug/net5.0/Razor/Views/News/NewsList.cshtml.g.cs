#pragma checksum "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e6174a285a03b32ebe5e257d54ad9596610dccc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_NewsList), @"mvc.1.0.view", @"/Views/News/NewsList.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e6174a285a03b32ebe5e257d54ad9596610dccc", @"/Views/News/NewsList.cshtml")]
    #nullable restore
    public class Views_News_NewsList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<News>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid img-responsive rounded product-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
  
	ViewBag.Title = "Tin Tức Bất động sản Nha Trang";
	Layout = "~/Views/_Layout.cshtml";

	string jsonStr = Context.Session.GetString("useraccount");
	User user = null;
	if (jsonStr != null) user = JsonConvert.DeserializeObject<User>(jsonStr);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
  
	List<News> NewsList = ViewBag.NewsList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
     if (@ViewBag.thongbao != null)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"		<div class=""container"">
			<div class=""row""><br></div>
			<div class=""row"">
				<div class=""col"">
				</div>
				<div class=""col-8"">
					<div class=""alert alert-info alert-dismissible fade show"" id='tempAlert' role=""alert"">
						<button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
							<span aria-hidden=""true"">&times;</span>
						</button>
						<strong>Thông báo</strong> ");
#nullable restore
#line 32 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                              Write(ViewBag.thongbao);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div class=\"col\">\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n");
#nullable restore
#line 39 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container mt-5 mb-5"">
	<div class=""d-flex justify-content-center row"">
		<div class=""col-md-10"">
			<div class=""col-12 mb-3  news1"" style=""background-color: #eee;"">
				<h2>Thông Tin Bất Động Sản Nha Trang Mới Nhất</h2>
			</div>
			<form action=""/tintuc/danhsach"">
			<div id=""paggertop"" class=""pagger"" style=""display:flex;"">
");
            WriteLiteral("\t\t\t\t<select name=\"sort\" class=\"custom-select col-3\" id=\"inlineFormCustomSelectPref\" onchange=\"this.form.submit()\">\r\n");
#nullable restore
#line 50 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                     if(ViewBag.sort==""){

#line default
#line hidden
#nullable disable
            WriteLiteral("<option");
            BeginWriteAttribute("value", " value=\"", 1591, "\"", 1599, 0);
            EndWriteAttribute();
            WriteLiteral(" selected>Sắp xếp</option>");
#nullable restore
#line 50 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                    }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<option");
            BeginWriteAttribute("value", " value=\"", 1639, "\"", 1647, 0);
            EndWriteAttribute();
            WriteLiteral(" >Sắp xếp</option>");
#nullable restore
#line 50 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                     if(ViewBag.sort=="des"){

#line default
#line hidden
#nullable disable
            WriteLiteral("<option value=\"des\" selected>Mới Nhất</option>");
#nullable restore
#line 51 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                           }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<option value=\"des\">Mới Nhất</option>");
#nullable restore
#line 51 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                                                      }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                     if(ViewBag.sort=="asc"){

#line default
#line hidden
#nullable disable
            WriteLiteral("<option value=\"asc\" selected>Cũ Nhất</option>");
#nullable restore
#line 52 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                          }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<option value=\"asc\">Cũ Nhất</option>");
#nullable restore
#line 52 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</select>\r\n");
            WriteLiteral("\t\t\t\t<div class=\"input-group mb-3 col-8\" style=\"margin-left: 25px\">\r\n\t\t\t\t\t<input name=\"search\"");
            BeginWriteAttribute("value", " value=\"", 2036, "\"", 2059, 1);
#nullable restore
#line 56 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 2044, ViewBag.search, 2044, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" type=""text"" class=""form-control"" placeholder=""Search"">
					<div class=""input-group-append"">
						<button class=""btn btn-light"" type=""submit"" style=""border: 1px solid #ced4da;""><i class=""bi bi-search""></i></button>
					</div>
				</div>
			</div><br></form>
");
#nullable restore
#line 62 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
             foreach (News n in NewsList)
		   {

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<div class=\"row p-2 bg-white border rounded\">\r\n\t\t\t\t<div class=\"col-md-3 mt-1\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7e6174a285a03b32ebe5e257d54ad9596610dccc10393", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2515, "~/myfiles/", 2515, 10, true);
#nullable restore
#line 65 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
AddHtmlAttributeValue("", 2525, n.ImgAvar, 2525, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n\t\t\t\t<div class=\"col-md-6 mt-1\">\r\n\t\t\t\t\t<h5>");
#nullable restore
#line 67 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                   Write(n.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
					<div class=""d-flex flex-row"">
						<div class=""ratings mr-2""><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i></div>
					</div>

					<p class=""text-justify text-truncate para mb-0""><ion-icon name=""calendar-outline"" role=""img"" class=""md hydrated"" aria-label=""calendar outline""></ion-icon>  ");
#nullable restore
#line 72 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                                                                                           Write(n.DateUp.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 72 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                                                                                                         Write(n.DateUp.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 72 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                                                                                                                         Write(n.DateUp.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br><br></p>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div class=\"align-items-center align-content-center col-md-3 border-left mt-1\">\r\n\r\n\t\t\t\t\t<h6 style=\"color: red;\">Đang HOT!</h6>\r\n\t\t\t\t\t<div class=\"d-flex flex-column mt-4\"><a class=\"btn btn-outline-primary\"");
            BeginWriteAttribute("href", " href=\"", 3258, "\"", 3285, 2);
            WriteAttributeValue("", 3265, "/tintuc?id=", 3265, 11, true);
#nullable restore
#line 77 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 3276, n.NewsId, 3276, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\">Xem ngay</a></div>\r\n");
#nullable restore
#line 78 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                         if (user!=null&&user.RoleId == 1)
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div");
            BeginWriteAttribute("class", " class=\"", 3382, "\"", 3390, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"padding-top: 20px;height: 70px;\">\r\n                        <a class=\"btn btn-outline-success\"");
            BeginWriteAttribute("href", " href=\"", 3492, "\"", 3539, 2);
            WriteAttributeValue("", 3499, "/tintucadmin/ChinhSuaTinTuc?id=", 3499, 31, true);
#nullable restore
#line 81 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 3530, n.NewsId, 3530, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\">Sửa</a>\r\n                        <a class=\"btn btn-outline-danger\" data-toggle=\"modal\" data-target=\"#exampleModal_");
#nullable restore
#line 82 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                    Write(n.NewsId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" role=\"button\">Xóa tin</a>\r\n\t\t\t\t\t\t<form method=\"post\" action=\"/tintucadmin/XoaTinTuc\">\r\n\t\t\t\t\t\t\t<div class=\"modal-dialog modal-dialog-centered\">\r\n\t\t\t\t\t\t\t<div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 3854, "\"", 3881, 2);
            WriteAttributeValue("", 3859, "exampleModal_", 3859, 13, true);
#nullable restore
#line 85 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 3872, n.NewsId, 3872, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
								<div class=""modal-dialog"">
									<div class=""modal-content"">
										<div class=""modal-header"">
											<h5 class=""modal-title"" id=""exampleModalLabel"">Thông báo</h5>
											<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
												<span aria-hidden=""true"">&times;</span>
											</button>
										</div>
										<div class=""modal-body"">
											Bạn có chắc muốn xóa tin tức này không?
											<input type=""text""");
            BeginWriteAttribute("value", " value=\"", 4439, "\"", 4456, 1);
#nullable restore
#line 96 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 4447, n.NewsId, 4447, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""id"" hidden>
										</div>
										<div class=""modal-footer"">
											<button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Thoát</button>
											<button type=""submit"" class=""btn btn-primary"">Có</button>
										</div>
									</div>
								</div>
							</div>
							</div>
						</form>
						</div>		
");
#nullable restore
#line 108 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
						}			

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>   \r\n");
#nullable restore
#line 111 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
		   }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t<br>\r\n\t\t\t<div id=\"paggerbot\" class=\"pagger\">\r\n\t\t\t\t<nav aria-label=\"...\">\r\n\t\t\t\t\t<ul class=\"pagination\">\r\n");
#nullable restore
#line 117 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                         if(ViewBag.PageEnd!=0){
						

#line default
#line hidden
#nullable disable
#nullable restore
#line 118 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                         if(ViewBag.PageIndex>2){

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<li class=\"page-item\">\r\n\t\t\t\t\t\t\t<a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5088, "\"", 5165, 4);
            WriteAttributeValue("", 5095, "/tintuc/danhsach?Pageindex=1&sort=", 5095, 34, true);
#nullable restore
#line 120 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5129, ViewBag.sort, 5129, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5142, "&search=", 5142, 8, true);
#nullable restore
#line 120 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5150, ViewBag.search, 5150, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Đầu</a>\r\n\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 122 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
						}

#line default
#line hidden
#nullable disable
#nullable restore
#line 124 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                         if (ViewBag.PageIndex !=1){int j =ViewBag.PageIndex-1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5318, "\"", 5396, 6);
            WriteAttributeValue("", 5325, "/tintuc/danhsach?Pageindex=", 5325, 27, true);
#nullable restore
#line 125 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5352, j, 5352, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5354, "&sort=", 5354, 6, true);
#nullable restore
#line 125 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5360, ViewBag.sort, 5360, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5373, "&search=", 5373, 8, true);
#nullable restore
#line 125 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5381, ViewBag.search, 5381, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 125 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                                                                 Write(j);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 126 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<li class=\"page-item active\" aria-current=\"page\">\r\n\t\t\t\t\t\t\t<a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5512, "\"", 5519, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 129 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                    Write(ViewBag.PageIndex);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 132 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                         if (ViewBag.PageIndex != ViewBag.PageEnd){int i =ViewBag.PageIndex+1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5687, "\"", 5765, 6);
            WriteAttributeValue("", 5694, "/tintuc/danhsach?Pageindex=", 5694, 27, true);
#nullable restore
#line 133 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5721, i, 5721, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5723, "&sort=", 5723, 6, true);
#nullable restore
#line 133 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5729, ViewBag.sort, 5729, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5742, "&search=", 5742, 8, true);
#nullable restore
#line 133 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5750, ViewBag.search, 5750, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 133 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                                                                                                                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 134 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
						}

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                         if (ViewBag.PageIndex <= ViewBag.PageEnd-1){

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<li class=\"page-item\">\r\n\t\t\t\t\t\t\t\t<a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5910, "\"", 6002, 6);
            WriteAttributeValue("", 5917, "/tintuc/danhsach?Pageindex=", 5917, 27, true);
#nullable restore
#line 138 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5944, ViewBag.PageEnd, 5944, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5960, "&sort=", 5960, 6, true);
#nullable restore
#line 138 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5966, ViewBag.sort, 5966, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5979, "&search=", 5979, 8, true);
#nullable restore
#line 138 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
WriteAttributeValue("", 5987, ViewBag.search, 5987, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Cuối</a>\r\n\t\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 140 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
						}

#line default
#line hidden
#nullable disable
#nullable restore
#line 140 "C:\Users\NOVAON\Downloads\Test_API_12-12\Project\Views\News\NewsList.cshtml"
                         
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t</ul>\r\n\t\t\t\t</nav>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<News> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
