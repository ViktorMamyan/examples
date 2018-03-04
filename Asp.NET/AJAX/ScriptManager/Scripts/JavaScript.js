function ShowMessage(msg)
{
    var span = document.getElementById('sp');
    span.innerHTML = msg;
}

function pageLoad()
{
    ShowMessage("AJAX");
}