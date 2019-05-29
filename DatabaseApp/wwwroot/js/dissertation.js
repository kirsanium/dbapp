// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

iduri = "api/chair/{id}";
uri = "http://localhost:5000/api/dissertation";
dissertationTableBody = null;

$(document).ready(function () {
    getAll();
});

function showItems(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    var keys = []
    var items = [];
    
    dissertationTableBody = $("#dissertationTableBody");
    dissertationTableBody.empty();

    $.each(data, function (k, row) {
        tr = $("<tr class=\"table-active\"></tr>");
        document.getElementById("changes").innerHTML = "row " + row;
        dissertationTableNames = $("#dissertationTableNames");
        dissertationTableNames.empty();
        $.each(Object.keys(row), function (kv, key) {
            document.getElementById("changes").innerHTML = "th " + key;
            th = "<th scope=\"col\">" + key + "</th>";
            $(dissertationTableNames).append(th);
        });
    
        $.each(row, function (key, val) {
            td = "<td>" + val + "</td>";
            $(tr).append(td);
        });
        tr.appendTo(dissertationTableBody);
    });

    document.getElementById("changes").innerHTML = "success";
}

function showItem(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    tr = $("<tr class=\"table-active\"></tr>");

    dissertationTableBody = $("#dissertationTableBody");
    dissertationTableBody.empty();
    dissertationTableNames = $("#dissertationTableNames");
    dissertationTableNames.empty();

    $.each(Object.keys(data), function (key, value) {
        th = "<th scope=\"col\">" + value + "</th>";
        $(dissertationTableNames).append(th);
    });

    $.each(data, function (key, val) {
        td = "<td>" + val + "</td>";
        $(tr).append(td);
    });

    tr.appendTo(dissertationTableBody);

    document.getElementById("changes").innerHTML = "success";
}

function getAll() {
    $.getJSON(uri, function(data){showItems(data)});
}

function showThemes(data) {
    dissertationTableBody = $("<tbody></tbody>");
    $.each(data.themes, function (key, val) {
        td = "<tr class=\"table-active\"><td>" + val + "</td></tr>";
        $(dissertationTableBody).append(td);
    });

    table = $("#dissertationTable");
    table.empty();
    table.append($("<thead> <th scope=\"col\">themes</th> </thead>"));
    table.append(dissertationTableBody);
}

function getData() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        id: $("#id").val()
        // facultyId: $("#facultyId").val(),
    };

    document.getElementById("changes").innerHTML = "id " + item.id + " " + (item.id == "");
    
    if (item.id == "") {
        getAll();
        return;
    }

    $.getJSON(uri + "/" + item.id, function (data) {
        showItem(data)
    });

    document.getElementById("changes").innerHTML = "success";
}

function getThemes() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        ChairId: $("#th_charid").val(),
        FacultyId: $("#th_facultyId").val()
    };
    
    var Uri = uri + "/themes?" + (item.ChairId == null ? "" : ("ChairId=" + item.ChairId)) + (item.ChairId == null ? "" : ("&FacultyId=" + item.FacultyId));

    $.getJSON(Uri, function (data) {
        showThemes(data)
    });

    // $.ajax({
    //     type: "GET",
    //     accepts: "application/json",
    //     url: uri + "themes?" + item.ChairId == null ? "" : ("ChairId=" + item.ChairId) + item.ChairId == null ? "" : ("&FacultyId=" + item.ChairId),
    //     contentType: "application/json",
    //     data: JSON.stringify(item),
    //     error: function (jqXHR, textStatus, errorThrown) {
    //         alert(uri + "themes " + JSON.stringify(item) + textStatus + errorThrown);
    //     },
    //     success: function (data) {
    //         showThemes(data)
    //         $("#th_facultyId").val(null);
    //         $("#th_charid").val(null);
    //     }
    // });

    document.getElementById("changes").innerHTML = "success";
}

function addItem() {
    item = {
        theme: $("#theme").val(),
        datePresented: $("#date").val(),
        teacherId: $("#teacherId").val(),
        dissertationTypeId: $("#dissertationTypeId").val()
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert(JSON.stringify(item) + textStatus + errorThrown);
        },
        success: function (data) {
            showItem(data)
            $("#theme").val(null),
            $("#date").val(null),
            $("#teacherId").val(null),
            $("#dissertationTypeId").val(null)
        }
    });

    document.getElementById("changes").innerHTML = "post request should be sent.";

}

function updateItem() {
    item = {
        theme: $("#puttheme").val(),
        datePresented: $("#putdate").val(),
        teacherId: $("#putteacherId").val(),
        dissertationTypeId: $("#putdissertationTypeId").val()
    };

    $.ajax({
        type: "PUT",
        accepts: "application/json",
        url: uri + "/" +  $("#putid").val(),
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert(JSON.stringify(item) + textStatus + errorThrown);
        },
        success: function (data) {
            showItem(data)
            $("#puttheme").val(null),
            $("#putdate").val(null),
            $("#putteacherId").val(null),
            $("#putdissertationTypeId").val(null)
        }
    });

    document.getElementById("changes").innerHTML = "post request should be sent." + (uri + $("#putid").val());

}

function deleteItem() {
    id = $("#deleteid").val();
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: function (result) {
            // getData();
        }
    });
}


function closeInput() {
    $("#spoiler").css({display: "none"});
}