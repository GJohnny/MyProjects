function sortByCategory(criteria) {
    debugger;
    $.ajax({
        url: "/Home/MenuSorted?criteria=" + criteria,
        method: "get",
        success: function (data) {
            $("#Menu-Items").html(data);
        }
    });
}