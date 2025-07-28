function toggleTheme() {
  const isDark = document.body.classList.toggle("dark-theme");
  localStorage.setItem("preferredTheme", isDark ? "dark" : "light");
  updateThemeButton(isDark);
}

function updateThemeButton(isDark) {
  const btn = document.getElementById("themeToggleBtn");
  if (!btn) return;

  if (isDark) {
    btn.innerHTML = "🌞";
  } else {
    btn.innerHTML = "🌙";
  }
}

window.addEventListener("DOMContentLoaded", () => {
  const preferredTheme = localStorage.getItem("preferredTheme");
  const isDark = preferredTheme === "dark";
  if (isDark) {
    document.body.classList.add("dark-theme");
  }
  updateThemeButton(isDark);
});