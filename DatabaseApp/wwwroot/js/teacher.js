// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

// iduri = "api/chair/{id}";
uri = "http://localhost:5000/api/teacher";
dissertationTableBody = null;

$(document).ready(function () {
    getAll();
});

function showItems(data) {
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
        ChairIds : $("#chairIds").tagsinput('items'),
        GenderId : $("#genderId").val(),
        BirthYearFrom : $("#birthYearFrom").val(),
        BirthYearTo: $("#birthYearTo").val(),
        AgeFrom : $("#ageFrom").val(),
        AgeTo : $("#ageTo").val(),
        HasChildren : $("#hasChildren").val(),
        ChildrenAmountFrom : $("#childrenFrom").val(),
        ChildrenAmountTo : $("#childrenTo").val(),
        SalaryAmountFrom : $("#SalaryAmountFrom").val(),
        SalaryAmountTo : $("#SalaryAmountTo").val(),
        isGraduateStudent : $("#isGraduateStudent").val(),
        DissertationTypeIds : $("#dissertationTypeIds").tagsinput('items'),
        TeacherCategoryIds : $("#teacherCategoryIds").tagsinput('items'),
        DateDissertationPresentedFrom : $("#DateDissertationPresentedFrom").val(),
        DateDissertationPresentedTo : $("#DateDissertationPresentedTo").val(),
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];
        
    Uri = $.param(item, true)

    $.getJSON(uri + "?" + Uri, function (data) {
        showItems(data)
    });

}

function get_lc() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        DisciplineId: $("#lc_DisciplineId").val(),
        FacultyId : $("#lc_FacultyId").val(),
        GroupId : $("#lc_GroupId").val(),
        Year : $("#lc_year").val(),
        LessonTypeIds : $("#lc_LessonTypeIds").tagsinput('items'),
        Semesters : $("#lc_semesters").tagsinput('items')
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);

    $.getJSON(uri + "/lessons-conducted?" + Uri, function (data) {
        showLc(data)
    });

    document.getElementById("changes").innerHTML = "success";

}

function get_finals() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        GroupIds : $("#f_groupIds").tagsinput('items'),
        DisciplineIds : $("#f_disciplineIds").tagsinput('items'),
        Semesters : $("#f_semesters").tagsinput('items')
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);

    $.getJSON(uri + "/by-finals?" + Uri, function (data) {
        showItems(data)
    });

    document.getElementById("changes").innerHTML = "success";

}

function get_thesis() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        ChairId : $("#thesis_chairIds").val(),
        FacultyId : $("#thesis_facultyId").val(),
        TeacherCategoryIds : $("#thesis_categoryIds").tagsinput('items')
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);

    $.getJSON(uri + "/thesis-teachers?" + Uri, function (data) {
        showItems(data)
    });

    document.getElementById("changes").innerHTML = "success";

}

function get_hours() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        TeacherId : $("#thours_TeacherId").val(),
        ChairId : $("#thours_ChairId").val(),
        Semester : $("#thours_Semester").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    Uri = $.param(item, true);

    $.getJSON(uri + "/hours?" + Uri, function (data) {
        showItems(data)
    });

    document.getElementById("changes").innerHTML = "success";

}

function addItem() {
    item = {
        firstName: $("#tnew_firstname").val(),
        secondName: $("#tnew_secondname").val(),
        middleName: $("#tnew_middlename").val(),
        birthDate: $("#tnew_birthdate").val(),
        childrenAmount: $("#tnew_childrenAmount").val(),
        salary: $("#tnew_salary").val(),
        graduateStudent: $("#tnew_isGraduateStudent").val(),
        chairId: $("#tnew_charId").val(),
        genderId: $("#tnew_genderId").val(),
        teacherCategoryId: $("#tnew_teacherCategoryId").val()
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
        firstName: $("#tinfo_firstname").val(),
        secondName: $("#tinfo_secondname").val(),
        middleName: $("#tinfo_middlename").val(),
        birthDate: $("#tinfo_birthdate").val(),
        childrenAmount: $("#tinfo_childrenAmount").val(),
        salary: $("#tinfo_salary").val(),
        graduateStudent: $("#tinfo_isGraduateStudent").val(),
        chairId: $("#tinfo_charId").val(),
        genderId: $("#tinfo_genderId").val(),
        teacherCategoryId: $("#tinfo_teacherCategoryId").val()
    };

    for(key in item)
        if(isEmpty(item[key]))
            delete item[key];

    $.ajax({
        type: "PUT",
        accepts: "application/json",
        url: uri + "/" +  $("#tinfo_id").val(),
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert(JSON.stringify(item) + textStatus + errorThrown);
        },
        success: function (data) {
            showItem(data)
            $("#tinfo_id").val(null);
            $("#tinfo_firstname").val(null);
            $("#tinfo_secondname").val(null);
            $("#tinfo_middlename").val(null);
            $("#tinfo_birthdate").val(null);
            $("#tinfo_childrenAmount").val(null);
            $("#tinfo_salary").val(null);
            $("#tinfo_isGraduateStudent").val(null);
            $("#tinfo_charId").val(null);
            $("#tinfo_genderId").val(null);
            $("#tinfo_teacherCategoryId").val(null);
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