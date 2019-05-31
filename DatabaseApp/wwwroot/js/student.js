// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

// iduri = "api/chair/{id}";
uri = "http://localhost:5000/api/student";
dissertationTableBody = null;

genders = {};
faculties = {};
chairs = {};
groups = {};
teachers = {};
disciplines = {};
students = {};

function fill_options() {

    $.getJSON("http://localhost:5000/api/academic-discipline", function (data) {
        $.each(data, function (key, value) {
            disciplines[value['id']] = value['name'];
        });

        eg_DisciplineId = $("#eg_DisciplineId");
        $.each(disciplines, function (key, value) {
            eg_DisciplineId.append('<option value=' + key + '>' + value + '</option>');
        });

        tg_disciplineIds = $("#tg_disciplineIds");
        $.each(disciplines, function (key, value) {
            tg_disciplineIds.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/teacher", function (data) {
        $.each(data, function (key, value) {
            teachers[value['id']] = value['firstName'] + " " + value['middleName'] + " " + value['secondName'];
        });

        tg_TeacherId = $("#tg_TeacherId");
        $.each(teachers, function (key, value) {
            tg_TeacherId.append('<option value=' + key + '>' + value + '</option>');
        });

        theses_TeacherId = $("#theses_TeacherId");
        $.each(teachers, function (key, value) {
            theses_TeacherId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/student", function (data) {
        $.each(data, function (key, value) {
            students[value['id']] = value['firstName'] + " " + value['middleName'] + " " + value['secondName'];
        });
        sinfo_id = $("#sinfo_id");
        $.each(students, function (key, value) {
            sinfo_id.append('<option value=' + key + '>' + value + '</option>');
        });

        deleteid = $("#deleteid");
        $.each(students, function (key, value) {
            deleteid.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/faculty", function (data) {
        $.each(data, function (key, value) {
            faculties[value['id']] = value['name'];
        });

        facultyId = $("#facultyId");
        $.each(faculties, function (key, value) {
            facultyId.append('<option value=' + key + '>' + value + '</option>');
        });

        snew_facultyId = $("#snew_facultyId");
        $.each(faculties, function (key, value) {
            snew_facultyId.append('<option value=' + key + '>' + value + '</option>');
        });

        session_facultyId = $("#session_facultyId");
        $.each(faculties, function (key, value) {
            session_facultyId.append('<option value=' + key + '>' + value + '</option>');
        });

        sinfo_facultyId = $("#sinfo_facultyId");
        $.each(faculties, function (key, value) {
            sinfo_facultyId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/chair", function (data) {
        $.each(data, function (key, value) {
            chairs[value['id']] = value['name'];
        });

        theses_ChairId = $("#theses_ChairId");
        $.each(chairs, function (key, value) {
            theses_ChairId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/gender", function (data) {
        $.each(data, function (key, value) {
            genders[value['id']] = value['name'];
        });

        genderId = $("#genderId");
        $.each(genders, function (key, value) {
            genderId.append('<option value=' + key + '>' + value + '</option>');
        });

        snew_genderId = $("#snew_genderId");
        $.each(genders, function (key, value) {
            snew_genderId.append('<option value=' + key + '>' + value + '</option>');
        });

        sinfo_genderId = $("#sinfo_genderId");
        $.each(genders, function (key, value) {
            sinfo_genderId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/group", function (data) {
        $.each(data, function (key, value) {
            groups[value['id']] = value['groupName'];
        });

        sl_groupIds = $("#sl_groupIds");
        $.each(groups, function (key, value) {
            sl_groupIds.append('<option value=' + key + '>' + value + '</option>');
        });

        snew_groupId = $("#snew_groupId");
        $.each(groups, function (key, value) {
            snew_groupId.append('<option value=' + key + '>' + value + '</option>');
        });

        eg_GroupIds = $("#eg_GroupIds");
        $.each(groups, function (key, value) {
            eg_GroupIds.append('<option value=' + key + '>' + value + '</option>');
        });

        tg_groupIds = $("#tg_groupIds");
        $.each(groups, function (key, value) {
            tg_groupIds.append('<option value=' + key + '>' + value + '</option>');
        });

        session_groupIds = $("#session_groupIds");
        $.each(groups, function (key, value) {
            session_groupIds.append('<option value=' + key + '>' + value + '</option>');
        });

        sinfo_groupId = $("#sinfo_groupId");
        $.each(groups, function (key, value) {
            sinfo_groupId.append('<option value=' + key + '>' + value + '</option>');
        });
    });
}

$(document).ready(function () {
    fill_options();
    
    getAll();
});

function showItems(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    dissertationTableBody = $("#dissertationTableBody");
    dissertationTableBody.empty();

    $.each(data, function (k, row) {
        if ('facultyId' in row) {
            row['faculty'] = faculties[row['facultyId']];
            delete row['facultyId'];
        }

        if ('genderId' in row) {
            row['gender'] = genders[row['genderId']];
            delete row['genderId'];
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

    document.getElementById("changes").innerHTML = "success";
}

function showTheses(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

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

        td = "<td>" + row['student']['firstName'] + " " + row['student']['secondName'] + " " + "</td>";
        $(tr).append(td);

        td = "<td>" + row['themes'] + "</td>";
        $(tr).append(td);
        
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

function showLc(data) {
    showItems(data['teachers'])
    // dissertationTableBody = $("<tbody></tbody>");
    // $.each(data.themes, function (key, val) {
    //     td = "<tr class=\"table-active\"><td>" + val + "</td></tr>";
    //     $(dissertationTableBody).append(td);
    // });
    //
    // table = $("#dissertationTable");
    // table.empty();
    // table.append($("<thead> <th scope=\"col\">themes</th> </thead>"));
    // table.append(dissertationTableBody);
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

function isEmpty(value){
    return value == null || value == "";
}

function getList() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        FacultyId : $("#facultyId").val(),
        Years : $("#sl_years").tagsinput('items'),
        GroupIds : $("#sl_groupIds").val(),
        GenderId : $("#genderId").val(),
        BirthYearFrom : $("#birthYearFrom").val(),
        BirthYearTo: $("#birthYearTo").val(),
        AgeFrom : $("#ageFrom").val(),
        AgeTo : $("#ageTo").val(),
        HasChildren : $("#hasChildren")[0].checked,
        ChildrenAmountFrom : $("#childrenFrom").val(),
        ChildrenAmountTo : $("#childrenTo").val(),
        HasScholarship : $("#hasScolarship")[0].checked,
        ScholarshipAmountFrom : $("#ScholarshipAmountFrom").val(),
        ScholarshipAmountTo : $("#ScholarshipAmountTo").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true)

    $.getJSON(uri + "?" + Uri, function (data) {
        showItems(data)
    });

}

function get_eg() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        DisciplineId: $("#eg_DisciplineId").val(),
        GroupIds : $("#eg_GroupIds").val(),
        Grade : $("#eg_Grade").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);

    $.getJSON(uri + "/by-exam-grade?" + Uri, function (data) {
        showLc(data)
    });

    document.getElementById("changes").innerHTML = "success";

}

function get_tg() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        GroupIds : $("#tg_groupIds").val(),
        TeacherId : $("#tg_TeacherId").val(),
        Grade : $("#tg_Grade").val(),
        DisciplineIds : $("#tg_disciplineIds").tagsinput('items'),
        Semesters : $("#tg_semesters").tagsinput('items'),
        DateFrom : $("#tg_dateFrom").val(),
        DateTo : $("#tg_dateTo").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);

    $.getJSON(uri + "/by-teacher-grade?" + Uri, function (data) {
        showItems(data)
    });

    document.getElementById("changes").innerHTML = "success";

}

function get_bysession() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        Semester : $("#semester").val(),
        GroupIds : $("#session_groupIds").val(),
        FacultyId : $("#session_facultyId").val(),
        Year : $("#session_year").val(),
        Grades : $("#session_grades").tagsinput('items')
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);

    $.getJSON(uri + "/by-session?" + Uri, function (data) {
        showItems(data['students'])
    });

    document.getElementById("changes").innerHTML = "success";

}

function get_theses() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        TeacherId : $("#theses_TeacherId").val(),
        ChairId : $("#theses_ChairId").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);

    $.getJSON(uri + "/theses-themes?" + Uri, function (data) {
        showTheses(data)
    });

}

function addItem() {
    item = {
        firstName: $("#snew_firstname").val(),
        secondName: $("#snew_secondname").val(),
        middleName: $("#snew_middlename").val(),
        birthDate: $("#snew_birthdate").val(),
        childrenAmount: $("#snew_childrenAmount").val(),
        scholarship : $("#snew_scholarship").val(),
        facultyId : $("#snew_facultyId").val(),
        groupId: $("#snew_groupId").val(),
        genderId: $("#snew_genderId").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

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
            $("#snew_firstname").val(null);
            $("#snew_secondname").val(null);
            $("#snew_middlename").val(null);
            $("#snew_birthdate").val(null);
            $("#snew_childrenAmount").val(null);
            $("#snew_scholarship").val(null);
            $("#snew_facultyId").val(null);
            $("#snew_groupId").val(null);
            $("#snew_genderId").val(null);
        }
    });

    document.getElementById("changes").innerHTML = "post request should be sent.";

}

function updateItem() {
    item = {
        firstName: $("#sinfo_firstname").val(),
        secondName: $("#sinfo_secondname").val(),
        middleName: $("#sinfo_middlename").val(),
        birthDate: $("#sinfo_birthdate").val(),
        childrenAmount: $("#sinfo_childrenAmount").val(),
        scholarship : $("#sinfo_scholarship").val(),
        facultyId : $("#sinfo_facultyId").val(),
        groupId: $("#sinfo_groupId").val(),
        genderId: $("#sinfo_genderId").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    $.ajax({
        type: "PUT",
        accepts: "application/json",
        url: uri + "/" +  $("#sinfo_id").val(),
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert(JSON.stringify(item) + textStatus + errorThrown);
        },
        success: function (data) {
            showItem(data);
            $("#sinfo_firstname").val(null);
            $("#sinfo_secondname").val(null);
            $("#sinfo_middlename").val(null);
            $("#sinfo_birthdate").val(null);
            $("#sinfo_childrenAmount").val(null);
            $("#sinfo_scholarship").val(null);
            $("#sinfo_facultyId").val(null);
            $("#sinfo_groupId").val(null);
            $("#sinfo_genderId").val(null);
        }
    });

    document.getElementById("changes").innerHTML = "post request should be sent." + (uri + $("#tinfo_id").val());

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