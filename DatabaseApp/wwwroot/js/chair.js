// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

iduri = "api/chair/{id}";
uri = "http://localhost:5000/api/chair/";
chairTable = null;

faculties = {};


$(document).ready(function() {
    $.getJSON("http://localhost:5000/api/faculty", function (data) {
        $.each(data, function (key, value) {
            faculties[value['id']] = value['name'];
        })
    });
});

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

function showItems(data) {

    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    dissertationTableBody = $("#dissertationTableBody");
    dissertationTableBody.empty();

    $.each(data, function (k, row) {
        if ('facultyId' in row) {
            row['faculty'] = faculties[row['facultyId']];
            delete row['facultyId'];
        }
        
        tr = $("<tr class=\"table-active\"></tr>");
        dissertationTableNames = $("#dissertationTableNames");
        dissertationTableNames.empty();
        $.each(Object.keys(row), function (kv, key) {
            th = "<th scope=\"col\">" + key + "</th>";
            $(dissertationTableNames).append(th);
        });

        $.each(row, function (key, val) {
            td = "<td>" + val + "</td>";
            $(tr).append(td);
        });
        tr.appendTo(dissertationTableBody);
    });

    document.getElementById("changes").innerHTML = "success ";
}

function getAll() {
    $.getJSON(uri, function(data){showItems(data)});
}

function getData() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        id: $("#id").val(),
        // facultyId: $("#facultyId").val(),
    };
    
    if (item.id == "") {
        getAll();
        return;
    }

    $.getJSON(uri + item.id, function(data){showItem(data)});
}

function isEmpty(value){
    return value == null || value == "";
}

function get_lc() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        GroupId : $("#lc_groupId").val(),
        FacultyId : $("#lc_facultyId").val(),
        Years : $("#lc_years").tagsinput('items'),
        Semesters : $("#lc_semesters").tagsinput('items'),
        DateFrom : $("#lc_datefrom").val(),
        DateTo : $("#lc_dateto").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);


    $.getJSON(uri + "lesson-conduction?" + Uri, function (data) {
        showItems(data);
    });

    document.getElementById("changes").innerHTML = "success";
}

function addItem() {
    item = {
        name: $("#name").val(),
        facultyId: $("#facultyId").val(),
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function(jqXHR, textStatus, errorThrown) {
            alert(JSON.stringify(item) + textStatus + errorThrown);
        },
        success: function(data){
            showItem(data)
            $("#name").val("");
            $("#facultyId").val(null);
        }
    });

    document.getElementById("changes").innerHTML = "post request should be sent.";

}

function updateItem() {
    item = {
        name: $("#putname").val(),
        facultyId: $("#putfacultyId").val()
    };

    $.ajax({
        type: "PUT",
        accepts:  "application/json",
        url: uri + $("#putid").val(),
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function(jqXHR, textStatus, errorThrown) {
            alert(JSON.stringify(item) + textStatus + errorThrown);
        },
        success: function(data) {
            showItem(data)
            $("#putid").val(null);
            $("#putname").val("");
            $("#putfacultyId").val(null);
        }
    });

    document.getElementById("changes").innerHTML = "post request should be sent.";

}

function deleteItem() {
    id = $("#deleteid").val();
    $.ajax({
        url: uri + id,
        type: "DELETE",
        success: function(result) {
            // getData();
        }
    });
}


function closeInput() {
    $("#spoiler").css({ display: "none" });
}