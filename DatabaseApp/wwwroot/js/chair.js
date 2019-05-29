// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// hello world

iduri = "api/chair/{id}";
uri = "http://localhost:5000/api/chair/";
chairTable = null;

$(document).ready(function() {
    getAll();
});

function showItem(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    tr = $("<tr class=\"table-active\"></tr>");
    chairTable = $("#chairTable");
    chairTable.empty()
    $.each(data, function(key, val){
        td = "<td>" + val +"</td>";
        $(tr).append(td);
    });

    tr.appendTo(chairTable);

    document.getElementById("changes").innerHTML = "success";
}

function showItems(data) {
    document.getElementById("changes").innerHTML = "proceeding changes " + data;

    chairTable = $("#chairTable");
    chairTable.empty()
    $.each(data, function (k, row) {
        document.getElementById("changes").innerHTML = "proceeding row " + row;
        tr = $("<tr class=\"table-active\"></tr>");
        $.each(row, function(key, val){
            td = "<td>" + val +"</td>";
            $(tr).append(td);
        });
        tr.appendTo(chairTable);
    })


    document.getElementById("changes").innerHTML = "success";
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