$(document).ready(function () {
    let detailUrl = '/Admin/GetMessageDetails';
    let LangUrl = '/Admin/GetUserlanguage';
    let AgeUrl = '/Admin/GetUserAge';
    let getGenderUrl = '/Admin/GetUserGender';

    callBarApi(detailUrl, 'Word', 'flot-bar-chart');
    callBarApi(LangUrl, 'Language', 'most-user-lang');
    callBarApi(AgeUrl, 'Name', 'user-year');


    
    let genderObject = {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    };
    fetch(getGenderUrl, genderObject).then((response) => {
        if (response.ok) {
            return response.json();
        } else {
            throw new Error('Something went wrong');
        }
    })
        .then((responsreJson) => {

            console.log(responsreJson);

            drawPie(responsreJson[0]['Count'], responsreJson[1]['Count']);
        })
        .catch((error) => {
            console.log(error);
        });





});