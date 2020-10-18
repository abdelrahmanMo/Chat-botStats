const checkLanguage = (message) => {

    let call = {
        method: 'POST'
    };

    const access_key = "8f5b8bd2c5ba8d328af0e6881c8482ee";
    fetch('http://api.languagelayer.com/detect?access_key=' + access_key + '&query=' + encodeURIComponent(message),
            call).then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        })
        .then((responseJson) => {
            let language = responseJson['results'][0]['language_name'];
            if (!language) {
                language = 'English';

            }
            saveInDatabase(message, language);

        })
        .catch((error) => {
            changeHtml('sorry,something went wrong please try again later', 'robot.png', 'left');
        });

};

