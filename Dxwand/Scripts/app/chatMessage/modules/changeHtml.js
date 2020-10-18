const changeHtml = (message, img, position) => {
    
    let chatDiscussion = $("#chat-discussion");
    let div = "<div class='chat-message " +
        position +
        "'>" +
        " <img class='message-avatar'  src ='../../Images/"+img+"'> " +
        "<div class='message'>" +
        "    <a class='message-author' href='#'> DXwandBot </a>" +
        "<span class='message-date'> Mon Jan 26 2015 - 18:39:23 </span>" +
        "<span class='message-content'>" +
        message +
        "" +
        "</span></div></div>";
    
    chatDiscussion.append(div);
    $('#message-avatar').attr('src', '../../Images/' + img);
};




 
    

    
    
    