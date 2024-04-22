function checkAnswers(index, num, correctAnswer) {
    if (num != 0) {
        if (num == correctAnswer) {
            localStorage.setItem(`Question ${index}`, 'correct');
        } else {
            localStorage.setItem(`Question ${index}`, 'incorrect');
        }
    } else {
        localStorage.setItem(`Question ${index}`, "empty");
    }
}

function getAnswer1() {
    return localStorage.getItem("Question 1");
}
function getAnswer2() {
    return localStorage.getItem("Question 2");
}
function getAnswer3() {
    return localStorage.getItem("Question 3");
}
function getAnswer4() {
    return localStorage.getItem("Question 4");
}
function getAnswer5() {
    return localStorage.getItem("Question 5");
}