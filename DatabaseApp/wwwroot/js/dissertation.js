// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

iduri = "api/chair/{id}";
uri = "http://localhost:5000/api/dissertation";
dissertationTableBody = null;

teachers = {};
dissertationTypes = {};
faculties = {};
chairs = {};
dissertations = {};

function fill_options() {

    $.getJSON("http://localhost:5000/api/teacher", function (data) {
        $.each(data, function (key, value) {
            teachers[value['id']] = value['firstName'] + " " + value['middleName'] + " " + value['secondName'];
        });
        teacherId = $("#teacherId");
        $.each(teachers, function (key, value) {
            teacherId.append('<option value=' + key + '>' + value + '</option>');
        });

        putteacherId = $("#putteacherId");
        $.each(teachers, function (key, value) {
            putteacherId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/dissertation-type", function (data) {
        $.each(data, function (key, value) {
            dissertationTypes[value['id']] = value['name'];
        });
        dissertationTypeId = $("#dissertationTypeId");
        $.each(dissertationTypes, function (key, value) {
            dissertationTypeId.append('<option value=' + key + '>' + value + '</option>');
        });

        putdissertationTypeId = $("#putdissertationTypeId");
        $.each(dissertationTypes, function (key, value) {
            putdissertationTypeId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/dissertation", function (data) {
        $.each(data, function (key, value) {
            dissertations[value['id']] = value['theme'];
        });
        putid = $("#putid");
        $.each(dissertations, function (key, value) {
            putid.append('<option value=' + key + '>' + value + '</option>');
        });

        id = $("#id");
        $.each(dissertations, function (key, value) {
            id.append('<option value=' + key + '>' + value + '</option>');
        });

        deleteid = $("#deleteid");
        $.each(dissertations, function (key, value) {
            deleteid.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/faculty", function (data) {
        $.each(data, function (key, value) {
            faculties[value['id']] = value['name'];
        });

        th_facultyId = $("#th_facultyId");
        $.each(faculties, function (key, value) {
            th_facultyId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/chair", function (data) {
        $.each(data, function (key, value) {
            chairs[value['id']] = value['name'];
        });

        th_charid = $("#th_charid");
        $.each(chairs, function (key, value) {
            th_charid.append('<option value=' + key + '>' + value + '</option>');
        });
    });
    
    facultyId = $("#facultyId");
    

    $.each(chairs, function (key, value) {
    });

    $.each(faculties, function (key, value) {
        // facultyId.append('<option value=' + key + '>' + value + '</option>');
    });
}

$(document).ready(function () {
    fill_options()
    // getAll();
});

function showItems(data) {
    
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    dissertationTableBody = $("#dissertationTableBody");
    dissertationTableBody.empty();

    $.each(data, function (k, row) {
        
        if ('teacherId' in row) {
            document.getElementById("changes").innerHTML = "proceeding changes " + row['teacherId'] + " " + teachers.keys;
            row['teacher'] = teachers[row['teacherId']];
            delete row['teacherId'];
        }

        if ('dissertationTypeId' in row) {
            row['dissertationType'] = dissertationTypes[row['dissertationTypeId']];
            delete row['dissertationTypeId'];
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
}

function showItem(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    if ('teacherId' in data) {
        data['teacher'] = teachers[data['teacherId']];
        delete data['teacherId'];
    }

    if ('dissertationTypeId' in data) {
        data['dissertationType'] = dissertationTypes[data['dissertationTypeId']];
        delete data['dissertationTypeId'];
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

function showThemes(data) {
    dissertationTableBody = $("<tbody id='dissertationTableBody'></tbody>");
    $.each(data.themes, function (key, val) {
        td = "<tr class=\"table-active\"><td>" + val + "</td></tr>";
        $(dissertationTableBody).append(td);
    });

    table = $("#dissertationTable");
    table.empty();
    table.append($("<thead id='dissertationTableNames'> <th scope=\"col\">themes</th> </thead>"));
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