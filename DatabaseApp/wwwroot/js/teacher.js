// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

// iduri = "api/chair/{id}";

uri = "http://localhost:5000/api/teacher";
dissertationTableBody = null;

chairs = {};
genders = {};
categories = {};
faculties = {};
groups = {};
teachers = {};
disciplines = {};
students = {};
dissertationTypes = {};
lessonTypes = {};

function fill_options() {

    $.getJSON("http://localhost:5000/api/academic-discipline", function (data) {
        $.each(data, function (key, value) {
            disciplines[value['id']] = value['name'];
        });

        lc_DisciplineId = $("#lc_DisciplineId");
        $.each(disciplines, function (key, value) {
            lc_DisciplineId.append('<option value=' + key + '>' + value + '</option>');
        });

        f_disciplineIds = $("#f_disciplineIds");
        $.each(disciplines, function (key, value) {
            f_disciplineIds.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/teacher", function (data) {
        $.each(data, function (key, value) {
            teachers[value['id']] = value['firstName'] + " " + value['middleName'] + " " + value['secondName'];
        });

        thours_TeacherId = $("#thours_TeacherId");
        $.each(teachers, function (key, value) {
            thours_TeacherId.append('<option value=' + key + '>' + value + '</option>');
        });

        tinfo_id = $("#tinfo_id");
        $.each(teachers, function (key, value) {
            tinfo_id.append('<option value=' + key + '>' + value + '</option>');
        });

        deleteid = $("#deleteid");
        $.each(teachers, function (key, value) {
            deleteid.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/student", function (data) {
        $.each(data, function (key, value) {
            students[value['id']] = value['firstName'] + " " + value['middleName'] + " " + value['secondName'];
        });
        // sinfo_id = $("#sinfo_id");
        // $.each(students, function (key, value) {
        //     sinfo_id.append('<option value=' + key + '>' + value + '</option>');
        // });
    });

    $.getJSON("http://localhost:5000/api/faculty", function (data) {
        $.each(data, function (key, value) {
            faculties[value['id']] = value['name'];
        });

        lc_FacultyId = $("#lc_FacultyId");
        $.each(faculties, function (key, value) {
            lc_FacultyId.append('<option value=' + key + '>' + value + '</option>');
        });

        thesis_facultyId = $("#thesis_facultyId");
        $.each(faculties, function (key, value) {
            thesis_facultyId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/chair", function (data) {
        $.each(data, function (key, value) {
            chairs[value['id']] = value['name'];
        });

        chairIds = $("#chairIds");
        $.each(chairs, function (key, value) {
            chairIds.append('<option value=' + key + '>' + value + '</option>');
        });

        tnew_charId = $("#tnew_charId");
        $.each(chairs, function (key, value) {
            tnew_charId.append('<option value=' + key + '>' + value + '</option>');
        });

        thesis_chairId = $("#thesis_chairId");
        $.each(chairs, function (key, value) {
            thesis_chairId.append('<option value=' + key + '>' + value + '</option>');
        });

        thours_ChairId = $("#thours_ChairId");
        $.each(chairs, function (key, value) {
            thours_ChairId.append('<option value=' + key + '>' + value + '</option>');
        });

        tinfo_charId = $("#tinfo_charId");
        $.each(chairs, function (key, value) {
            tinfo_charId.append('<option value=' + key + '>' + value + '</option>');
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

        tnew_genderId = $("#tnew_genderId");
        $.each(genders, function (key, value) {
            tnew_genderId.append('<option value=' + key + '>' + value + '</option>');
        });

        tinfo_genderId = $("#tinfo_genderId");
        $.each(genders, function (key, value) {
            tinfo_genderId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/group", function (data) {
        $.each(data, function (key, value) {
            groups[value['id']] = value['groupName'];
        });

        lc_GroupId = $("#lc_GroupId");
        $.each(groups, function (key, value) {
            lc_GroupId.append('<option value=' + key + '>' + value + '</option>');
        });
        
        f_groupIds = $("#f_groupIds");
        $.each(groups, function (key, value) {
            f_groupIds.append('<option value=' + key + '>' + value + '</option>');
        });
    });
    
    $.getJSON("http://localhost:5000/api/teacher-category", function (data) {
        $.each(data, function (key, value) {
            categories[value['id']] = value['name'];
        });

        teacherCategoryIds = $("#teacherCategoryIds");
        $.each(categories, function (key, value) {
            teacherCategoryIds.append('<option value=' + key + '>' + value + '</option>');
        });

        tnew_teacherCategoryId = $("#tnew_teacherCategoryId");
        $.each(categories, function (key, value) {
            tnew_teacherCategoryId.append('<option value=' + key + '>' + value + '</option>');
        });

        thesis_categoryIds = $("#thesis_categoryIds");
        $.each(categories, function (key, value) {
            thesis_categoryIds.append('<option value=' + key + '>' + value + '</option>');
        });

        tinfo_teacherCategoryId = $("#tinfo_teacherCategoryId");
        $.each(categories, function (key, value) {
            tinfo_teacherCategoryId.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/dissertation-type", function (data) {
        $.each(data, function (key, value) {
            dissertationTypes[value['id']] = value['name'];
        });
        dissertationTypeIds = $("#dissertationTypeIds");
        $.each(dissertationTypes, function (key, value) {
            dissertationTypeIds.append('<option value=' + key + '>' + value + '</option>');
        });
    });

    $.getJSON("http://localhost:5000/api/lesson-type", function (data) {
        $.each(data, function (key, value) {
            lessonTypes[value['id']] = value['name'];
        });

        lc_LessonTypeIds = $("#lc_LessonTypeIds");
        $.each(lessonTypes, function (key, value) {
            lc_LessonTypeIds.append('<option value=' + key + '>' + value + '</option>');
        });
    });
}

$(document).ready(function () {
    fill_options();

    getAll();
});

//
// $(document).ready(function () {
//     $.getJSON("http://localhost:5000/api/chair", function (data) {
//         $.each(data, function (key, value) {
//             chairs[value['id']] = value['name'];
//         })
//     });
//
//     $.getJSON("http://localhost:5000/api/gender", function (data) {
//         $.each(data, function (key, value) {
//             genders[value['id']] = value['name'];
//         })
//     });
//
//     $.getJSON("http://localhost:5000/api/teacher-category", function (data) {
//         $.each(data, function (key, value) {
//             categories[value['id']] = value['name'];
//         })
//     });
//    
//     getAll();
// });

function showItems(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    dissertationTableBody = $("#dissertationTableBody");
    dissertationTableBody.empty();

    $.each(data, function (k, row) {
        if ('chairId' in row) {
            row['chair'] = chairs[row['chairId']];
            delete row['chairId'];
        }

        if ('genderId' in row) {
            row['gender'] = genders[row['genderId']];
            delete row['genderId'];
        }

        if ('teacherCategoryId' in row) {
            row['teacherCategory'] = categories[row['teacherCategoryId']];
            delete row['teacherCategoryId'];
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
}

function isEmpty(value){
    return value == null || value == "";
}

function getList() {
    document.getElementById("changes").innerHTML = "running...";

    item = {
        ChairIds : $("#chairIds").val(),
        GenderId : $("#genderId").val(),
        BirthYearFrom : $("#birthYearFrom").val(),
        BirthYearTo: $("#birthYearTo").val(),
        AgeFrom : $("#ageFrom").val(),
        AgeTo : $("#ageTo").val(),
        HasChildren : $("#hasChildren")[0].checked,
        ChildrenAmountFrom : $("#childrenFrom").val(),
        ChildrenAmountTo : $("#childrenTo").val(),
        SalaryAmountFrom : $("#SalaryAmountFrom").val(),
        SalaryAmountTo : $("#SalaryAmountTo").val(),
        isGraduateStudent : $("#isGraduateStudent")[0].checked,
        DissertationTypeIds : $("#dissertationTypeIds").val(),
        TeacherCategoryIds : $("#teacherCategoryIds").val(),
        DateDissertationPresentedFrom : $("#DateDissertationPresentedFrom").val(),
        DateDissertationPresentedTo : $("#DateDissertationPresentedTo").val()
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
        LessonTypeIds : $("#lc_LessonTypeIds").val(),
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
        GroupIds : $("#f_groupIds").val(),
        DisciplineIds : $("#f_disciplineIds").val(),
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
        TeacherCategoryIds : $("#thesis_categoryIds").val()
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
        data_hours = new Set([]);
        $.each(data, function (key, value) {
            $.each(value['disciplineHours'], function (key, value) {
                data_hours.add(value['disciplineName']);
            })
        });
        
        existing_lessons = new Set([]);
        $.each(data, function (key, value) {
            data_hours.forEach(function (k, enter, data_hours) {
                // document.getElementById("changes").innerHTML = "success" + enter;
                value[enter + " lections"] = "";
                value[enter + " seminars"] = "";
                $.each(value['disciplineHours'], function (key, discipline) {
                    if (enter == discipline['disciplineName']) {
                        value[enter + " lections"] = discipline['lessonTypeHours'][0]['hours'];
                        existing_lessons.add(enter + " lections")
                        if (discipline['lessonTypeHours'].length > 1) {
                            value[enter + " seminars"] = discipline['lessonTypeHours'][1]['hours'];
                            existing_lessons.add(enter + " seminars")
                        }
                    }
                });
            });
            delete value['disciplineHours'];
            data[key] = value;
        });
        data_hours.forEach(function (k, enter, data_hours) {
            if (!existing_lessons.has(enter + " lections")) {
                $.each(data, function (key, value) {
                    delete value[enter + " lections"];
                });
            }
            if (!existing_lessons.has(enter + " seminars")) {
                $.each(data, function (key, value) {
                    delete value[enter + " seminars"];
                });
            }
        });
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
        graduateStudent: $("#tnew_isGraduateStudent")[0].checked,
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