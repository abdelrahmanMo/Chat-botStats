const chatResponse = (message, userId) => {
    let url =
        "https://account.snatchbot.me/channels/api/api/id137612/appdxwand110695ad/apsmo4abo2som5ng11096?user_id=" +
            userId;
    let callObject = {
        method: 'post',
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: { 'message': message }
    };
    fetch(url, callObject).then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        })
        .then((responseJson) => {
            let message = responseJson['messages'][Math.floor(Math.random() * 8)]['message'];
            changeHtml(message, 'robot.png', 'left');
           
        })
        .catch((error) => {
            changeHtml('sorry,something went wrong please try again later', 'robot.png', 'left');
        });
}

