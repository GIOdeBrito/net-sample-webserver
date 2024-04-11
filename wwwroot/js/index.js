

window.addEventListener('load', function ()
{
    controls();
});

function controls ()
{
    window['btime'].onclick = async () =>
    {
        let res = await timeRequest();
        let json = JSON.parse(res.response);

        window['result'].innerText = 'Current time: ' + json.result;
    };

    window['buser'].onclick = async () =>
    {
        setUser();
    };
}

async function timeRequest ()
{
    const req = new XMLHttpRequest();
    
    req.open("GET", "/api/time", true);
    req.send();

    return new Promise(resolve =>
    {
        req.onload = (res) => resolve({
            status: res.target.status,
            response: res.target.responseText,
            raw: res
        });
    });
}

async function setUser ()
{
    let name = String(window.prompt("Inform name"));
    let age = Number(window.prompt("Inform age"));

    const req = new XMLHttpRequest();
    req.open("POST", "/api/setuser", true);
    req.setRequestHeader("Content-Type", "application/json");

    let json = {
        name: name,
        age: age
    };

    req.send(JSON.stringify(json));

    req.onload = () =>
    {
        if(req.status === 200)
        {
            window.location.reload();
        }
    };
}

