/*
	Designed by: SELECTO
	Original image: https://dribbble.com/shots/5311359-Diprella-Login
*/

// انشاء متغيرات للاشتراكات والعناصر الأخرى
let switchCtn = document.querySelector("#switch-cnt");
let switchC1 = document.querySelector("#switch-c1");
let switchC2 = document.querySelector("#switch-c2");
let switchCircle = document.querySelectorAll(".switch__circle");
let switchBtn = document.querySelectorAll(".switch-btn");
let aContainer = document.querySelector("#a-container");
let bContainer = document.querySelector("#b-container");
let allButtons = document.querySelectorAll(".submit");

// دالة تمنع إعادة تحميل الصفحة عند النقر على الزر
let getButtons = (e) => e.preventDefault();

// دالة تغيير النموذج عند النقر على الزر
let changeForm = (e) => {
	// إضافة وإزالة الفئات للتحكم في التأثيرات البصرية
	switchCtn.classList.add("is-gx");
	setTimeout(function () {
		switchCtn.classList.remove("is-gx");
	}, 1500);

	switchCtn.classList.toggle("is-txr");
	switchCircle[0].classList.toggle("is-txr");
	switchCircle[1].classList.toggle("is-txr");

	switchC1.classList.toggle("is-hidden");
	switchC2.classList.toggle("is-hidden");
	aContainer.classList.toggle("is-txl");
	bContainer.classList.toggle("is-txl");
	bContainer.classList.toggle("is-z200");
};

// دالة رئيسية لإضافة الأحداث عند تحميل الصفحة
let mainF = (e) => {
	// إضافة الأحداث لجميع الأزرار
	for (var i = 0; i < allButtons.length; i++)
		allButtons[i].addEventListener("click", getButtons);

	// إضافة الأحداث لأزرار التبديل بين الصفحتين
	for (var i = 0; i < switchBtn.length; i++)
		switchBtn[i].addEventListener("click", changeForm);
};

// استدعاء الدالة الرئيسية عند تحميل الصفحة
window.addEventListener("load", mainF);
