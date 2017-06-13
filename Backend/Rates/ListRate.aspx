﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListRate.aspx.cs" Inherits="Backend_Rates_ListRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
             <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">List Rate</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Banner</h2>
                <div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon white wrench"></i></a>
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-up"></i></a>
                    <a href="#" class="btn-close"><i class="halflings-icon white remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <table class="table table-striped table-bordered bootstrap-datatable datatable">
                    <thead>
                        <tr>
                            <th>RateId</th>
                            <th>AlbumId</th>
                            <th>Rates</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="center">Member</td>
                            <td class="center">asdasdasd
                            </td>
                            <td class="center">13</td>
                            <td class="center">
                                <a class="btn btn-info" href="#">
                                    <i class="halflings-icon white edit"></i>
                                </a>
                                <a class="btn btn-danger" href="#">
                                    <i class="halflings-icon white trash"></i>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <!--/span-->

    </div>
    <!--/row-->
</asp:Content>

