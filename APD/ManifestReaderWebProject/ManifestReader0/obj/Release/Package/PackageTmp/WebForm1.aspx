<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ManifestReader0.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Manifest reader</title>
    <!-- Bootstrap Core CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <style>
        body {
            padding-top: 70px;
            /* Required padding for .navbar-fixed-top. Remove if using .navbar-static-top. Change if height of navigation changes. */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Under Construction -->
        <div class="modal fade" id="underConstructionModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title textCenter" id="myModalLabel">Configuration</h4>
                    </div>
                    <div class="modal-body underConstruction">
                        <div>
                            Manifest folders Path:
                        </div>
                        <div>
                            <asp:TextBox ID="txtMasterPath" runat="server" Text="C:\Users\GAMBOAJ\Documents\ExportedDemo" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnMasterPath" runat="server" Text="Accept" class="btn btn-success" OnClick="btnMasterPath_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- END Under Construction -->
        <!-- Navigation -->
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="container">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Manifest reader
                    </a>
                    &nbsp;
                </div>
                <ul class="nav navbar-nav navbar-right">
                    <li><a data-toggle="modal" data-target="#underConstructionModal"><span class="glyphicon glyphicon-pencil"></span></a></li>
                    <li><a><asp:Label ID="lblMasterPath" runat="server" Text="path"></asp:Label></a></li>

                </ul>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container -->
        </nav>
        <!-- Page Content -->

        <div>
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Folder name</th>
                                </tr>
                            </thead>
                            <tbody id="foldersTbody" runat="server">
                                <%--                            <tr>
                                <td><span class="glyphicon glyphicon-folder-open" aria-hidden="true"></span></td>
                                <td></td>
                            </tr>--%>
                            </tbody>
                        </table>
                    </div>
                    <br />
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <div id="row">
                            <div class="col-md-8">
                                <h4 class="modal-title" id="folderNameLabel">Folder name</h4>
                                <h5 id="numFilesTitle" class="modal-title">Number of files: </h5>
                                <a id="numFiles">number</a>

                                <input type="text" name="realNameASP" id="realNameASP" runat="server" style="display: none" />
                                <input type="text" name="convertedNameASP" id="convertedNameASP" runat="server" style="display: none" />
                                <input type="text" name="pathFileASP" id="pathFileASP" runat="server" style="display: none" />
                                <asp:LinkButton ID="hideDownload2" runat="server" OnClick="btnDownloadFile_Click" Style="display: none"></asp:LinkButton>


                            </div>
                            <div class="col-md-4">
                                <div id="loading">
                                    <p>
                                        <img src="srs/ellipsis.gif" height="42" width="42" />
                                    </p>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-body">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>File Name</th>
                                </tr>
                            </thead>
                            <tbody id="TbodyFiles" runat="server">
                                <%--                            <tr>
                                <td><span class="glyphicon glyphicon-folder-open" aria-hidden="true"></span></td>
                                <td></td>
                            </tr>--%>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- jQuery Version 1.11.1 -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.js"></script>
        <!-- Bootstrap Core JavaScript -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        <script>
            //Under construction script
            $('#underConstructionModal').modal('show');

            function hideFirstModal() {
                $('#underConstructionModal').modal('hide');
            }

            function showFirstModal() {
                $('#underConstructionModal').modal('show');
            }

            var actionPath;

            function getNumberOfFiles(path, dirname) {
                $.ajax({
                    type: "GET",
                    url: "WebForm1.aspx/getNumberOfFiles",
                    contentType: "application/json; charset=utf-8",
                    data: { 'folder': "'" + path + "'" },
                    dataType: 'json',
                    success: function (dictionary) {
                        actionPath = path;
                        paintNumberOfFiles(dictionary.d);
                    },
                    error: function (e) {
                        alert("Error, from the server side " + e.Message);
                    }
                });
            }

            function getDocuments(path, dirname) {
                showLoading();
                $.ajax({
                    type: "GET",
                    url: "WebForm1.aspx/getFileandOriginalName",
                    contentType: "application/json; charset=utf-8",
                    data: { 'folder': "'" + path + "'" },
                    dataType: 'json',
                    success: function (dictionary) {
                        actionPath = path;
                        getNumberOfFiles(path, dirname);
                        paintDocumentTable(dirname, dictionary.d);
                        hideLoading();
                    },
                    error: function (e) {
                        alert("Error, from the server side " + e.Message);
                    }
                });
            }

            function paintNumberOfFiles(numberOfFiles) {
                $("#numFiles").empty();
                $("#numFiles").html(numberOfFiles);
            }

            function paintDocumentTable(folderName, dictionary) {
                cleaner();
                $("#folderNameLabel").html(folderName);
                var number = 1;
                for (var key in dictionary) {
                    //alert(' name=' + key + ' value=' + dictionary[key]);
                    var buttonASP = "<button id=\"btnDownloadFile\" type=\"button\" class=\"btn\" onclick=\"downloadServer('" + key + "','" + dictionary[key] + "','" + folderName + "')\"><span class=\"glyphicon glyphicon-save-file\" aria-hidden=\"true\"></span></button>";
                    var table = "<tr><td>" + buttonASP + "</td><td>" + dictionary[key] + "</td><td>" + number + "</td></tr>";
                    number++;
                    $("#TbodyFiles").append(table);
                }
            }
            function cleaner() {
                $("#TbodyFiles").empty();
            }

            function showLoading() {
                $("#loading").show();
            }

            function hideLoading() {
                $("#loading").hide();
            }

            function downloadServer(realNameFV, convertedNameFV, pathFileFV) {
                $("#realNameASP").val(realNameFV);
                $("#convertedNameASP").val(convertedNameFV);
                $("#pathFileASP").val(pathFileFV);
                document.getElementById('<%= hideDownload2.ClientID %>').click();
            }

            //
        </script>

    </form>

</body>
</html>
