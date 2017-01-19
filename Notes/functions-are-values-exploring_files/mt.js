function hideDocumentElement(id) {
    var el = document.getElementById(id);
    if (el) el.style.display = 'none';
}

function showDocumentElement(id) {
    var el = document.getElementById(id);
    if (el) el.style.display = 'block';
}

function showAnonymousForm() {
    showDocumentElement('comments-form');

}


var commenter_name;
var commenter_blog_ids;
var is_preview;
var mtcmtmail;
var mtcmtauth;
var mtcmthome;

function individualArchivesOnLoad(commenter_name) {



    hideDocumentElement('trackbacks-info');



    if (document.comments_form) {
        if (!commenter_name && (document.comments_form.email != undefined) &&
            (mtcmtmail = getCookie("mtcmtmail")))
            document.comments_form.email.value = mtcmtmail;
        if (!commenter_name && (document.comments_form.author != undefined) &&
            (mtcmtauth = getCookie("mtcmtauth")))
            document.comments_form.author.value = mtcmtauth;
        if (document.comments_form.url != undefined &&
            (mtcmthome = getCookie("mtcmthome")))
            document.comments_form.url.value = mtcmthome;
        if (document.comments_form["bakecookie"]) {
            if (mtcmtauth || mtcmthome) {
                document.comments_form.bakecookie.checked = true;
            } else {
                document.comments_form.bakecookie.checked = false;
            }
        }
    }
}

function writeCommenterGreeting(commenter_name, entry_id, blog_id, commenter_id, commenter_url) {

}



// Copyright (c) 1996-1997 Athenia Associates.
// http://www.webreference.com/js/
// License is granted if and only if this entire
// copyright notice is included. By Tomer Shiran.

function setCookie (name, value, expires, path, domain, secure) {
    var curCookie = name + "=" + escape(value) + (expires ? "; expires=" + expires : "") +
        (path ? "; path=" + path : "") + (domain ? "; domain=" + domain : "") + (secure ? "secure" : "");
    document.cookie = curCookie;
}

function getCookie (name) {
    var prefix = name + '=';
    var c = document.cookie;
    var nullstring = '';
    var cookieStartIndex = c.indexOf(prefix);
    if (cookieStartIndex == -1)
        return nullstring;
    var cookieEndIndex = c.indexOf(";", cookieStartIndex + prefix.length);
    if (cookieEndIndex == -1)
        cookieEndIndex = c.length;
    return unescape(c.substring(cookieStartIndex + prefix.length, cookieEndIndex));
}

function deleteCookie (name, path, domain) {
    if (getCookie(name))
        document.cookie = name + "=" + ((path) ? "; path=" + path : "") +
            ((domain) ? "; domain=" + domain : "") + "; expires=Thu, 01-Jan-70 00:00:01 GMT";
}

function fixDate (date) {
    var base = new Date(0);
    var skew = base.getTime();
    if (skew > 0)
        date.setTime(date.getTime() - skew);
}

function rememberMe (f) {
    var now = new Date();
    fixDate(now);
    now.setTime(now.getTime() + 365 * 24 * 60 * 60 * 1000);
    now = now.toGMTString();
    if (f.author != undefined)
       setCookie('mtcmtauth', f.author.value, now, '/', '', '');
    if (f.email != undefined)
       setCookie('mtcmtmail', f.email.value, now, '/', '', '');
    if (f.url != undefined)
       setCookie('mtcmthome', f.url.value, now, '/', '', '');
}

function forgetMe (f) {
    deleteCookie('mtcmtmail', '/', '');
    deleteCookie('mtcmthome', '/', '');
    deleteCookie('mtcmtauth', '/', '');
    f.email.value = '';
    f.author.value = '';
    f.url.value = '';
}

/* Tag Cloud Display */

function show_all_tags () {
	document.getElementById('default-cloud').style.display="none";
	document.getElementById('full-cloud').style.display="";
}

function hide_all_tags () {
	document.getElementById('default-cloud').style.display="";
	document.getElementById('full-cloud').style.display="none";
}

/* Threaded comment functions */

function mtShow(id) {
    var el = (typeof id == "string") ? document.getElementById(id) : id;
    if (el) el.style.display = 'block';
}
function mtSetCommentParentID() {
    var checkbox = document.getElementById('comment-reply');
    var parent_id_field = document.getElementById('comment-parent-id');
    if (!checkbox || !parent_id_field) return;
    var pid = 0;
    if (checkbox.checked == true)
        pid = checkbox.value;
    parent_id_field.value = pid;
}
function mtReplyCommentOnClick(parent_id, author) {
    mtShow('comment-form-reply');
    var checkbox = document.getElementById('comment-reply');
    var label = document.getElementById('comment-reply-label');
    var text = document.getElementById('comment-text');
    // Populate label with new values
    var reply_text = 'Replying to <a href="#comment-'+ parent_id +'" onclick="location.href=this.href; return false">comment from '+ author +'</a>';
    label.innerHTML = reply_text;
    checkbox.value = parent_id; 
    checkbox.checked = true;
    text.focus();
    mtSetCommentParentID();
}

