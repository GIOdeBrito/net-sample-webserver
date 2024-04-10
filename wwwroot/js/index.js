

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
}

async function timeRequest ()
{
    const req = new XMLHttpRequest();
    
    req.open("GET", "api/time", true);
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


