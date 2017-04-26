<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSWebParts_Vector_ImageOnlyContent"  CodeBehind="~/CMSWebParts/Vector/ImageOnlyContent.ascx.cs" %>

<!-- start of Image Only Content -->
<div class="image-only">
    <div>
        <cms:CMSEditableRegion ID="CMSEditableRegion1" runat="server" RegionTitle="Image Description" DialogHeight="200" HtmlAreaToolbar="Full" RegionType="HTMLEditor" HtmlAreaToolbarLocation="In" />
    </div>
    <div>
        <cms:CMSEditableImage ID="CMSEditableImage1" runat="server" ImageTitle="Image Content" DisplaySelectorTextBox="true" AlternateText="Image Content Goes Here"/>
    </div>
</div>
<!-- end of Image Only Content -->