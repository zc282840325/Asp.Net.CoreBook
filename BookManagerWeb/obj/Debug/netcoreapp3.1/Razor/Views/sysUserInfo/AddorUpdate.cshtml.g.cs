#pragma checksum "E:\Studying\Asp.Net.CoreBook\BookManagerWeb\Views\sysUserInfo\AddorUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16a98d27c5c242df827f81fbc981420200cc0be1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_sysUserInfo_AddorUpdate), @"mvc.1.0.view", @"/Views/sysUserInfo/AddorUpdate.cshtml")]
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
#line 1 "E:\Studying\Asp.Net.CoreBook\BookManagerWeb\Views\_ViewImports.cshtml"
using BookManagerWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Studying\Asp.Net.CoreBook\BookManagerWeb\Views\_ViewImports.cshtml"
using BookManagerWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16a98d27c5c242df827f81fbc981420200cc0be1", @"/Views/sysUserInfo/AddorUpdate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28bf2d3ba0f83d7d4e1a3c0a978ccc9e64fbefea", @"/Views/_ViewImports.cshtml")]
    public class Views_sysUserInfo_AddorUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Studying\Asp.Net.CoreBook\BookManagerWeb\Views\sysUserInfo\AddorUpdate.cshtml"
  
    Layout ="_Layout2";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <title>");
#nullable restore
#line 6 "E:\Studying\Asp.Net.CoreBook\BookManagerWeb\Views\sysUserInfo\AddorUpdate.cshtml"
      Write(ViewData["title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</title>\r\n<script type=\"text/javascript\">\r\n    $(function () {\r\n        var uid = 0;\r\n        if (");
#nullable restore
#line 10 "E:\Studying\Asp.Net.CoreBook\BookManagerWeb\Views\sysUserInfo\AddorUpdate.cshtml"
       Write(ViewData["uid"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("!= null) {\r\n              var uid =");
#nullable restore
#line 11 "E:\Studying\Asp.Net.CoreBook\BookManagerWeb\Views\sysUserInfo\AddorUpdate.cshtml"
                  Write(ViewData["uid"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
        }

        if (uid!=0) {
            $.ajax({
                method: ""post"",
                url: ""http://129.211.11.64:801/api/sysUserInfo/GetByIdAsync?id="" + uid,
                 dataType: ""json"",//数据类型
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
                success: function (res) {
                    debugger;
                    alert(res);
                },
                error: function (xhr) {
                    alert(""出错了!"");
                }
            });
        }
    });
</script>
<script type=""text/template"" id=""bondTemplateList"">
    <div class=""layui-fluid"">
        <div class=""layui-row"">
            <form class=""layui-form"">
                <div class=""layui-form-item"">
                    <label for=""username"" class=""layui-form-label"">
                        <span class=""x-red"">*</span>登录名
                    </label>
                    <div class");
            WriteLiteral(@"=""layui-input-inline"">
                        <input type=""text"" id=""uLoginName"" name=""uLoginName"" required="""" lay-verify=""required""
                               autocomplete=""off"" class=""layui-input""
                               value=""{{ d.uLoginName?d.uLoginName:'' }}"" {{# if(d.uID){ }}disabled{{# } }}>

                    </div>
                    <div class=""layui-form-mid layui-word-aux"">
                        <span class=""x-red"">*</span>将会成为您唯一的登入名
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label for=""L_email"" class=""layui-form-label"">
                        <span class=""x-red"">*</span>真实姓名
                    </label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" id=""uRealName"" name=""uRealName"" required="""" lay-verify=""required""
                               autocomplete=""off"" class=""layui-input""
                               value=""{{ d.uRealName?d.uR");
            WriteLiteral(@"ealName:'' }}"" {{# if(d.uID){ }} disabled{{# } }}>
                    </div>
                    <div class=""layui-form-mid layui-word-aux"">
                        <span class=""x-red"">*</span>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label for=""L_pass"" class=""layui-form-label"">
                        <span class=""x-red"">*</span>密码
                    </label>
                    <div class=""layui-input-inline"">
                        <input type=""password"" id=""uLoginPWD"" name=""uLoginPWD"" required="""" lay-verify=""pass""
                               autocomplete=""off"" class=""layui-input"">
                    </div>
                    <div class=""layui-form-mid layui-word-aux"">
                        6到16个字符
                    </div>
                </div>
");
            WriteLiteral(@"                <div class=""layui-form-item"">
                    <label for=""L_repass"" class=""layui-form-label"">
                        <span class=""x-red"">*</span>身份证号
                    </label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" id=""IDNumber"" name=""IDNumber"" required="""" lay-verify=""repass""
                               autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label for=""L_repass"" class=""layui-form-label"">
                        <span class=""x-red"">*</span>出生日期
                    </label>
                    <div class=""layui-input-inline"">
                        <input type=""date"" id=""Birthday"" name=""Birthday"" required="""" lay-verify=""repass""
                               autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item"">
 ");
            WriteLiteral(@"                   <label for=""L_repass"" class=""layui-form-label"">
                        <span class=""x-red"">*</span>简介
                    </label>
                    <div class=""layui-input-inline"">
                        <textarea name=""uRemark"" id=""uRemark"" required lay-verify=""required"" placeholder=""请输入"" class=""layui-textarea""></textarea>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">性别</label>
                    <div class=""layui-input-block"">
                        <input type=""radio"" name=""Sex"" value=""男"" title=""男"">
                        <input type=""radio"" name=""Sex"" value=""女"" title=""女"" checked>
                    </div>
                </div>

                <div class=""layui-form-item"">
                    <label for=""L_repass"" class=""layui-form-label"">
                    </label>
                    <button class=""layui-btn"" lay-filter=""add"" lay-submit="""">
            ");
            WriteLiteral(@"            增加
                    </button>
                </div>
                <input type=""hidden"" id=""uID"" name=""uID"" value=""0"" />
                <input type=""hidden"" id=""uStatus"" name=""uStatus"" value=""0"" />
                <input type=""hidden"" id=""uCreateTime"" name=""uCreateTime"" value=""2020-06-24T15:17:15.801Z"" />
                <input type=""hidden"" id=""tdIsDelete"" name=""tdIsDelete"" value=""false"" />
                <input type=""hidden"" id=""IsReportLoss"" name=""IsReportLoss"" value=""0"" />
                <input type=""hidden"" id=""uUpdateTime"" name=""uUpdateTime"" value=""2020-06-24T15:17:15.801Z"" />
                <input type=""hidden"" id=""uErrorCount"" name=""uErrorCount"" value=""0"" />
                <input type=""hidden"" id=""uLastErrTime"" name=""uLastErrTime"" value=""2020-06-24T15:17:15.801Z"" />
                <input type=""hidden"" id=""Borrows"" name=""Borrows"" value=""0"" />
                <input type=""hidden"" id=""Borroweds"" name=""Borroweds"" value=""0"" />
                <input type=""hidden"" id=""Unp");
            WriteLiteral(@"aidFine"" name=""UnpaidFine"" value=""0"" />
            </form>
        </div>
    </div>
</script>
    <script>
        layui.use(['form', 'layer'],
            function () {
                $ = layui.jquery;
                var form = layui.form,
                    layer = layui.layer;

                //自定义验证规则
                form.verify({
                    nikename: function (value) {
                        if (value.length < 5) {
                            return '昵称至少得5个字符啊';
                        }
                    },
                    pass: [/(.+){6,12}$/, '密码必须6到12位'],
                    repass: function (value) {
                        if ($('#L_pass').val() != $('#L_repass').val()) {
                            return '两次密码不一致';
                        }
                    }
                });

                //监听提交
                form.on('submit(add)',
                    function (data) {
                        $.ajax({
                            ty");
            WriteLiteral(@"pe: ""post"",
                            url: ""http://129.211.11.64:801/api/sysUserInfo/Add"",
                            dataType: ""json"",
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            data: JSON.stringify(data.field),
                            success: function (responseTxt) {
                                if (responseTxt.msg == ""添加成功"") {
                                    layer.alert(""增加成功"", {
                                        icon: 6
                                    },
                                        function () {
                                            //关闭当前frame
                                            xadmin.close();

                                            // 可以对父窗口进行刷新
                                            xadmin.father_reload();
                                    ");
            WriteLiteral(@"    });
                                } else {
                                    layer.msg(responseTxt.msg);
                                }
                            }
                        });
                        return false;
                        ////发异步，把数据提交给php
                        //layer.alert(""增加成功"", {
                        //    icon: 6
                        //},
                        //    function () {
                        //        //关闭当前frame
                        //        xadmin.close();

                        //        // 可以对父窗口进行刷新
                        //        xadmin.father_reload();
                        //    });
                        //return false;
                    });

            });</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
