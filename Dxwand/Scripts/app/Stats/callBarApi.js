const callBarApi = (apiUrl,name,id) => {
    let li = [];
    let ticks = []

    let getUrl = apiUrl;
    let chatObject = {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    };
    fetch(getUrl, chatObject).then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        })
        .then((responseJson) => {
            responseJson.map((response, index) => {

                let arr = new Array(2);
                let tick = new Array(2);
                arr[0] = index;
                arr[1] = response['Count'];
                tick[0] = index;
                tick[1] = response[name];
                li.push(arr);
                ticks.push(tick);


            });
            console.log(li);
            console.log(ticks);
            drawBar(ticks, li, id);
        })
        .catch((error) => {
            console.log(error);
        });
}