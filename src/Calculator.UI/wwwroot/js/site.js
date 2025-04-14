const display = document.getElementById("display");
const buttons = document.querySelectorAll(".btn-calculator");
const toggleBtn = document.getElementById("toggleMode");

let current = "0";
let operator = null;
let previous = null;

toggleBtn.addEventListener("click", () => {
    document.body.classList.toggle("day-mode");
    toggleBtn.textContent = document.body.classList.contains("day-mode") ? "🌙" : "☀️";
});

async function calculateRemote(a, b, op) {
    const response = await fetch("/api/calculate", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ a, b, operation: op })
    });
    const result = await response.json();
    return result.value;
}

document.addEventListener("keydown", async (event) => {
    const key = event.key;

    if (!isNaN(Number(key))) {
        current = current === "0" ? key : current + key;
    } else if (key === "Backspace" || key === 'Escape') {
        current = "0";
        previous = null;
        operator = null;
    } else if (key === ".") {
        if (!current.includes(".")) current += ".";
    } else if (key === "%") {
        current = String(Number(current) / 100);
    } else if (["+", "-", "*", "/"].includes(key)) {
        operator = key === "*" ? "×" : key === "/" ? "÷" : key;
        previous = current;
        current = "0";
    } else if (key === "Enter" || key === "=") {
        if (operator && previous !== null) {
            try {
                current = await calculateRemote(previous, current, operator);
            } catch {
                current = "Err";
            }
            previous = null;
            operator = null;
        }
    } else if (key.toLowerCase() === "m") {
        toggleBtn.click();
    }

    display.textContent = current;
});

buttons.forEach(btn => {
    btn.addEventListener("click", async () => {
        const value = btn.textContent.trim();

        if (!isNaN(Number(value))) {
            current = current === "0" ? value : current + value;
        } else if (value === "AC") {
            current = "0";
            previous = null;
            operator = null;
        } else if (value === ".") {
            if (!current.includes(".")) current += ".";
        } else if (value === "+/-") {
            current = String(Number(current) * -1);
        } else if (value === "%") {
            current = String(Number(current) / 100);
        } else if (["+", "-", "×", "÷"].includes(value)) {
            operator = value;
            previous = current;
            current = "0";
        } else if (value === "=") {
            if (operator && previous !== null) {
                try {
                    current = await calculateRemote(previous, current, operator);
                } catch (err) {
                    current = "Err";
                }
                previous = null;
                operator = null;
            }
        }
        display.textContent = current;
    });
});