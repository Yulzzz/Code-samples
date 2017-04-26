<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamProfileControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.TeamProfileControl" %>

<asp:Panel runat="server" ID="TeamPanel" >
<script type="text/javascript">
    var nextPage = 1;
        
    $(document).ready(function () {
        loadNextPage('<%= Path%>', '<%= PageSize%>', 1, '#<%= TeamPanel.ClientID%>');

        $('#<%= TeamPanel.ClientID%>').find('.btnLoadMore').click(function () {
            $('#<%= TeamPanel.ClientID%>').find('.person').show();
            loadNextPage('<%= Path%>', '<%= PageSize%>', nextPage, '#<%= TeamPanel.ClientID%>');
            return false;
        });
    });

    function loadNextPage(path, pageSize, pageIndex, selectorPrefix) {

        //load the second page after page is loaded
        $.ajax({
            url: "/api/teamprofile?path=" + path + "&pageIndex=" + pageIndex + "&pageSize=" + pageSize,
            })
            .success(function (data) {
                if (data.length) {

                    $(data).each(function (index, value) {

                        var newPerson = $(selectorPrefix).find(".personTemplate").clone();

                        if (value.Picture) {
                            $(newPerson).find('img').attr("src", value.Picture);
                        }
                        else {
                            $(newPerson).find('img').remove();
                        }

                        if (value.FirstName) {
                            $(newPerson).find('.name').html(value.FirstName + ' ' + value.LastName);
                        }
                        else {
                            $(newPerson).find('.name').remove();
                        }

                        if (value.Qualification) {
                            $(newPerson).find('.qualification').html(value.Qualification);
                        }
                        else {
                            $(newPerson).find('.qualification').remove();
                        }

                        if (value.Highlight) {
                            $(newPerson).find('.highlights').html(value.Highlight);
                        }
                        else {
                            $(newPerson).find('.highlights').remove();
                        }

                        if (value.Details) {
                            $(newPerson).find('.details').html(value.Details);
                        }
                        else {
                            $(newPerson).find('.details').remove();
                        }
                        newPerson.removeClass('personTemplate');
                        newPerson.addClass('person');

                        $(selectorPrefix).find(".peopleList").append(newPerson);
                    });

                    $(selectorPrefix).find('.btnLoadMore').show();
                    nextPage = pageIndex + 1;
                }
                else {
                    $(selectorPrefix).find('.btnLoadMore').hide();
                }
            })
            .error(function (error) {
                // handle the error
            });

        return false;
    }

</script>

<div class="peopleList">
 <cms:CMSRepeater runat="server" ID="PeopleRepeater" >
        <ItemTemplate>
                <div class="person">
                    <img src="<%# Eval("Picture") %>" />
                    <h6><%# Eval("FirstName") + " " + Eval("LastName") %></h6>
                    <p class="qualification"><%# Eval("Qualification") %></p>
                    <p class="highlights"><%# Eval("Highlight") %></p>
                    <p><%# Eval("Details") %></p>
                </div>
        </ItemTemplate>
    </cms:CMSRepeater>
    
</div>

<div class="load-more">
    <a class="vctr-btn btn vctr-button-primary btnLoadMore" href="#" >Load More</a>
</div>

<div class="personTemplate" style="display:none;">
    <img src="/"/>
    <h6 class="name"></h6>
    <p class="qualification"></p>
    <p class="highlights"></p>
    <p class="details"></p>
</div>
<!-- end of Team Profile -->
</asp:Panel>


<asp:Panel ID="DesignPanel" runat="server">
    <p>There is a team profile control here, it is not displayed in Design Mode. Please switch to view mode to see it</p>
</asp:Panel>