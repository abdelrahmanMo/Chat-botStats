

var userId = document.getElementById('userId').value;
console.log(userId);

    
        $('#send').click(function () {
            let messageVal = $('#chatMessage').val();
            console.log(messageVal.length);
            if (/\S/.test(messageVal)) {
                chatResponse(messageVal, userId);
                 checkLanguage(messageVal);
                changeHtml(messageVal, 'man-avatar.png', 'right');
                $(':input[name="message"]').val('');
            }
            
        });

let perValue = '';
        var format = /[!#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/;
        $('#chatMessage').keyup((e) => {
          if (!format.test(e.target.value) === false) {
            $('#send').prop('disabled', false);
              $('#chatMessage').val(perValue);
              changeHtml('sorry,we don\'t accept any sort of special characters', 'robot.png', 'left');
            } else {
            perValue = e.target.value;
            }
        });

    

   