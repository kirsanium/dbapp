// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

iduri = "api/chair/{id}";
uri = "http://localhost:5000/api/academic-assignment";
dissertationTableBody = null;
chairs = {};
faculties = {};
groups = {};
teachers = {};
disciplines = {};
assignments = {};

function fill_options() {

    $.getJSON("http://localhost:5000/api/academic-discipline", function (data) {
        $.each(data, function (key, value) {
            disciplines[value['id']] = value['name'];
        });

        discipline = $("#discipline");
        $.each(disciplines, function (key, value) {
            discipline.append('<option value=' + key + '>' + value + '</option>');
        });

        putdiscipline = $("#putdiscipline");
        $.each(disciplines, function (key, value) {
            putdiscipline.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/teacher", function (data) {
        $.each(data, function (key, value) {
            teachers[value['id']] = value['firstName'] + " " + value['middleName'] + " " + value['secondName'];
        });

        // thours_TeacherId = $("#thours_TeacherId");
        // $.each(teachers, function (key, value) {
        //     thours_TeacherId.append('<option value=' + key + '>' + value + '</option>');
        // });
    });

    $.getJSON("http://localhost:5000/api/faculty", function (data) {
        $.each(data, function (key, value) {
            faculties[value['id']] = value['name'];
        });

        // lc_FacultyId = $("#lc_FacultyId");
        // $.each(faculties, function (key, value) {
        //     lc_FacultyId.append('<option value=' + key + '>' + value + '</option>');
        // });
    });

    $.getJSON("http://localhost:5000/api/chair", function (data) {
        $.each(data, function (key, value) {
            chairs[value['id']] = value['name'];
        });

        putchair = $("#putchair");
        $.each(chairs, function (key, value) {
            putchair.append('<option value=' + key + '>' + value + '</option>');
        });

        chairId = $("#chairId");
        $.each(chairs, function (key, value) {
            chairId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/group", function (data) {
        $.each(data, function (key, value) {
            groups[value['id']] = value['groupName'];
        });

        group = $("#group");
        $.each(groups, function (key, value) {
            group.append('<option value=' + key + '>' + value + '</option>');
        });

        putgroup = $("#putgroup");
        $.each(groups, function (key, value) {
            putgroup.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/academic-assignment", function (data) {
        $.each(data, function (key, value) {
            var dateFrom = convertDate(new  Date(value['dateFrom']));
            var dateTo = convertDate(new Date(value['dateTo']));
            assignments[value['id']] = chairs[value['chairId']] 
                + " " + disciplines[value['disciplineId']] 
                + " " + groups[value['groupId']] 
                + " " + dateFrom 
                + "-" + dateTo;
        });

        putid = $("#putid");
        deleteid = $("#deleteid");
        id = $("#id");
        $.each(assignments, function (key, value) {
            putid.append('<option value=' + key + '>' + value + '</option>');
            deleteid.append('<option value=' + key + '>' + value + '</option>');
            id.append('<option value=' + key + '>' + value + '</option>');
        });
    });
}

function convertDate(date) {
    yr      = date.getFullYear();
    month   = date.getMonth() < 10 ? '0' + date.getMonth() : date.getMonth();
    day     = date.getDate()  < 10 ? '0' + date.getDate()  : date.getDate();
    
    return [day, month, yr].join('.');
}

$(document).ready(function () {
    fill_options();

    // getAll();
});

function showItems(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    dissertationTableBody = $("#dissertationTableBody");
    dissertationTableBody.empty();

    $.each(data, function (k, row) {
        if ('disciplineId' in row) {
            row['discipline'] = disciplines[row['disciplineId']];
            delete row['disciplineId'];
        }

        if ('chairId' in row) {
            row['chair'] = chairs[row['chairId']];
            delete row['chairId'];
        }

        if ('groupId' in row) {
            row['group'] = groups[row['groupId']];
            delete row['groupId'];
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
        data['discipline'] = disciplines[data['disciplineId']];
        delete data['disciplineId'];
    }

    if ('chairId' in data) {
        data['chair'] = chairs[data['chairId']];
        delete data['chairId'];
    }

    if ('groupId' in row) {
        row['group'] = groups[row['groupId']];
        delete row['groupId'];
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
        chairId: $("#chairId").val(),
        disciplineId: $("#discipline").val(),
        groupId: $("#group").val(),
        dateFrom: $("#dateFrom").val(),
        dateTo: $("#dateTo").val()
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
            $("#chairId").val(null);
            $("#discipline").val(null);
            $("#group").val(null);
            $("#dateFrom").val(null);
            $("#dateTo").val(null);
        }
    });

    document.getElementById("changes").innerHTML = "post request should be sent.";

}

function updateItem() {
    item = {
        chairId: $("#putchair").val(),
        disciplineId: $("#putdiscipline").val(),
        groupId: $("#putgroup").val(),
        dateFrom: $("#putdateFrom").val(),
        dateTo: $("#putdateTo").val()
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
            $("#putchair").val(null);
            $("#putdiscipline").val(null);
            $("#putgroup").val(null);
            $("#putdateFrom").val(null);
            $("#putdateTo").val(null);
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