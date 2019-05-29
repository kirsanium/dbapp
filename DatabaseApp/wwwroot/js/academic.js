// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

iduri = "api/chair/{id}";
uri = "http://localhost:5000/api/academic-assignment";
dissertationTableBody = null;
teachers = {};
chairs = {};

$(document).ready(function () {
    $.getJSON("http://localhost:5000/api/academic-discipline", function (data) {
            $.each(data, function (key, value) {
                teachers[value['id']] = value['name']; 
            })
    });
    $.getJSON("http://localhost:5000/api/chair", function (data) {
        $.each(data, function (key, value) {
            chairs[value['id']] = value['name'];
        })
    });
    
    // getAll();
});

function showItems(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    var keys = []
    var items = [];

    dissertationTableBody = $("#dissertationTableBody");
    dissertationTableBody.empty();

    $.each(data, function (k, row) {
        if ('disciplineId' in row) {
            row['discipline'] = teachers[row['disciplineId']];
            delete row['disciplineId'];
        }

        if ('chairId' in row) {
            row['chair'] = chairs[row['chairId']];
            delete row['chairId'];
        }

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

    // document.getElementById("changes").innerHTML = "success";
}

function showItem(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    if ('disciplineId' in data) {
        data['discipline'] = teachers[data['disciplineId']];
        delete data['disciplineId'];
    }

    if ('chairId' in data) {
        data['chair'] = chairs[data['chairId']];
        delete data['chairId'];
    }

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

function addItem() {
    item = {
        semester: $("#theme").val(),
        name: $("#name").val(),
        facultyId: $("#facultyId").val(),
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
            $("#theme").val(null);
            $("#name").val(null);
            $("#facultyId").val(null);
        }
    });

    document.getElementById("changes").innerHTML = "post request should be sent.";

}

function updateItem() {
    item = {
        semester: $("#puttheme").val(),
        name: $("#putname").val(),
        facultyId: $("#putfacultyId").val(),
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
            $("#puttheme").val(null);
            $("#putname").val(null);
            $("#putfacultyId").val(null);
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