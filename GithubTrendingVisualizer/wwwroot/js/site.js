﻿
/*
 * Handlers
 */

$(".ui.dropdown")
    .dropdown();

$(".save-repository-button")
    .on("click", saveRepository);

/*
 * Functions
 */

function saveRepository(event) {

    $(event.currentTarget).addClass("loading");

    var id = "#" + $(event.currentTarget).data("id");
    var model = createSaveRepositoryModel(id);

    $.ajax({
        url: "Repositories/SaveRepository",
        type: "POST",
        async: true,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(model),
        success: function (result) {

            if (Boolean(result)) { saveRepositorySucceeded(event); }
            else { saveRepositoryFailed(); }
        },
        error: function (result) {

            saveRepositoryFailed();
        }
    });
}

function createSaveRepositoryModel(id) {

    var model = {};

    $(id).each(function () {

        var inputs = $(this).find("input").serializeArray();

        $.each(inputs, function (index, value) {

            model[value["name"]] = value["value"];
        });
    });

    console.log(model);
    return model;
}

function saveRepositorySucceeded(event) {

    $(event.currentTarget)
        .removeClass("loading primary")
        .addClass("basic");

    $(event.currentTarget)
        .find("[data-button='icon']")
        .removeClass("save")
        .addClass("checkmark");

    $(event.currentTarget)
        .find("[data-button='text']")
        .html("Saved");
}

function saveRepositoryFailed() {

    alert("Oops...");
}