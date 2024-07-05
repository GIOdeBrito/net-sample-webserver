

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

    window['buser'].onclick = () =>
    {
        setUser();
    };
}

async function timeRequest ()
{
    const req = new XMLHttpRequest();
    
    req.open("GET", "/api/v1/time", true);
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
    req.open("POST", "/api/v2/setuser", true);
    req.setRequestHeader("Content-Type", "application/json");

    const json = {
        name: name,
        age: age
    };

    req.send(JSON.stringify(json));

    req.onload = () =>
    {
        if(req.status === 200)
        {
            window.location.reload();
            return;
        }

        console.error(req.status);
    };
}


