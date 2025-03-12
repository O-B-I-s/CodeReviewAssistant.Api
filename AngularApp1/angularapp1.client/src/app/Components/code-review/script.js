const phrases = [
  "AI-Powered Code Review Assistant",
  "Enhancing Code Quality with AI",
  "Smart Reviews, Better Code",
  "Built by Johnson Obioma"
];

let index = 0;
const animatedText = document.getElementById("animatedText");

function updateText() {
  if (animatedText) {
    animatedText.textContent = phrases[index];
    index = (index + 1) % phrases.length;
  }
}

// Initial call and interval setup
updateText();
setInterval(updateText, 3000);
