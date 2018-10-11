
      //Modal kapama işlemini yönetir.
      function HideModal(modalId, completeEvent) {
          $('#' + modalId).on(modalId + 'hide', function () {
              if (Boolean($('#' + modalId).data('destroynested'))) {
                  $('#divPageContent > [data-isnested="true"]').not('[data-destroynested="true"]').each(function () {
                      $(this).remove();
                  });
              };
              if (typeof completeEvent == "function") {
                  completeEvent();
              };
          });
          $('#' + modalId).find('.modal-dialog:first').closest(".modal").modal("hide");
      };

//Modal açma işlemini yönetir.
function ShowModal(modalId, completeEvent) {

    $('#' + modalId).on(modalId + 'show', function () {
        var zIndex = 1060 + (10 * $('.modal:visible').length);
        $(this).css('z-index', zIndex);
        setTimeout(function () {
            $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
        }, 0);
        if (typeof completeEvent == "function") {
            completeEvent();
        };
    });

    if (Boolean($('#' + modalId).data('isnested'))) {
        if ($('#divPageContent > #' + modalId).length > 0) {
            $('#divPageContent > #' + modalId).modal('show');
        } else {
            $('#' + modalId).appendTo('#divPageContent').modal('show');
        };
    } else {
        $('#' + modalId).modal('show');
    };
};

        
var $tree;

$(document).ready(function () {
    LocationTreeLoad();
    BtnLocationSaveClick();
    BtnInsertRootLocation();
});

function LocationTreeLoad() {
    $tree = $("#divLocationTree").on('changed.jstree', function (e, data) {
        if (data != null && data.node != null && data.node.state.selected) {
            $('#btnSubLocation, #btnUpdateLocation, #btnDeleteLocation').show();
        } else {
            $('#btnSubLocation, #btnUpdateLocation, #btnDeleteLocation').hide();
        };
    }).bind("move_node.jstree", function (e, data) {
        Ajax.Post('/Location/UpdateLocationParent', {
            locationId: data.node.id,
            parentId: (data.parent == "#" ? null : data.parent)
        }, function (result) {
            if (Number(result) > 0) {
                alert('Bilgi', 'Birim hiyerarşi değişikliği başarıyla gerçekleştirildi!');
            };
        });
    }).jstree({
        "core": {
            "multiple": false,
            "themes": { "responsive": false },
            "check_callback": true,
            "data": function (node, cb) {
                Ajax.Get('/Location/GetLocationsByParentId', { parentId: (node.id === "#" ? null : node.id) }, function (result) {
                    var $data = [];
                    if (result != null && result.length > 0) {
                        $.each(result, function (i, item) {
                            $data.push({
                                id: item.Id,
                                text: item.Name,
                                children: item.HasChild
                            });
                        });
                    };
                    cb($data);
                });
            }
        },
        "types": {
            "default": {
                "icon": "fa fa-folder icon-state-warning icon-lg"
            },
            "file": {
                "icon": "fa fa-file icon-state-warning icon-lg"
            }
        },
        "plugins": ["dnd", "types"]
    });
};
/*
function BtnInsertRootLocation() {
    $('#btnInsertRootLocation').click(function () {
        $('#divParentLocationName').hide();
        //
        Ajax.Get('/Location/Create', { id: GetSelectedNodeInformation().id }, function (result) {

            ShowModal('divLocationModal');
        });
        // ShowModal('divLocationModal');
    });
};*/

function BtnLocationSaveClick() {
    $('#btnLocationSave').click(function () {
        $tree.jstree("refresh");
        //  ShowAlert('Bilgi', 'Birim bilgisi başarıyla kaydedildi.');
    });
};


function InsertSubLocation() {
    $('#hfParentId').val(GetSelectedNodeInformation().id);
    $('#txtParentLocationName').val(GetSelectedNodeInformation().text);
    $('#divParentLocationName').show();
    ShowModal('divLocationModal');
};
function AddUnderLocation() {
    Ajax.Get('/Location/UpdateLocation', { id: GetSelectedNodeInformation().id }, function (result) {
        SetFormValue2(result);
        $('#hfParentId').val(GetSelectedNodeInformation().id);
        $('#txtParentLocationName').val(GetSelectedNodeInformation().text);
        $('#divParentLocationName').show();

        $("#frmLocation").prop("action", "/Location/CreateChild");
        ShowModal('divLocationModal');
    });
};
function AddNormalLocation() {
    $('#btnInsertRootLocation').click(function () {

        Ajax.Post('/Location/CreateLocat', function (result) {

            SetFormValue(result);
            $("#frmLocation").prop("action", "/Location/CreateNormalLocation");
            ShowModal('divLocationModal');
        });
    });
};

function BtnInsertRootLocation() {
    $('#btnInsertRootLocation').click(function () {
        $('#divParentLocationName').hide();
        $("#hfParentId").val("0");
        $("#frmLocation").prop("action", "/Location/CreateNormalLocation");
        ShowModal('divLocationModal');
    });
};

function ClearForm()
{
    $("#hfId").val("");
    $("#hfParentId").val("");
    $("#txtName").val("");
    $("#txtDescription").val("");
}

function UpdateLocation() {
    $('#divParentLocationName').hide();
    Ajax.Get('/Location/UpdateLocation', { id: GetSelectedNodeInformation().id }, function (result) {
        SetFormValue(result);
        $("#frmLocation").prop("action", "/Location/Update");
        ShowModal('divLocationModal');
    });
};

function SetFormValue2(data) {
    $("#hfId").val("");
    $("#hfParentId").val(data.ParentId);
    $("#txtName").val("");
    $("#txtDescription").val("");
}


function SetFormValue(data) {
    $("#hfId").val(data.Id);
    $("#hfParentId").val(data.ParentId);
    $("#txtName").val(data.Name);
    $("#txtDescription").val(data.Description);
}

function DeleteLocation() {

    Ajax.Post('/Location/Delete', { locationId: GetSelectedNodeInformation().id }, function (result) {
        $tree.jstree("refresh");
    });
};

function GetSelectedNodeInformation() {
    var $node = $tree.jstree(true).get_selected('full', true)[0];
    var $index = $tree.find('[id="' + $node.id + '"]').index();
    return {
        id: $node.id,
        text: $node.text,
        index: ($index + 2)
    };
};

