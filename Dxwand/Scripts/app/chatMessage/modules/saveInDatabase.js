const saveInDatabase = (message,language) => {

    let data = {
        'Message': message,
        'Language':language
    } 
    console.log(data)
    let saveUrl = '/Home/SaveMessageInDatabase';
    let chatObject = {
        method: 'post',
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(data) 
    };
    fetch(saveUrl, chatObject).then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        })
        .then((responseJson) => {
            
        })
        .catch((error) => {
            changeHtml('sorry,something went wrong please try agin later', 'robot.png', 'left');
        });
};