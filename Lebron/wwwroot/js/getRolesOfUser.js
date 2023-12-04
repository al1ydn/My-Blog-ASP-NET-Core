function getRolesOfUser() {
    let userSelect = document.getElementById('userSelect');
    let userSelected = userSelect.options[userSelect.selectedIndex].value;

    $.ajax({
        url: '/Admin/Role/GetRolesOfUser',
        data: { userName: userSelected },
        success: function (view) {
            $('#GetRolesOfUserView').html(view);
        }
    });
}
