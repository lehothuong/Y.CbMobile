import Vue from "vue";
Vue.mixin({
  created() {
    this.formatPrice();
  },
  updated() {
    this.reloadImg();
  },
  methods: {
    formatPrice(value) {
      let val = (value / 1).toFixed(0).replace(".", ",");
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") + "₫";
    },
    loadImage(e) {
      e.classList.add("fade-in"), (e.src = e.dataset.src);
    },
    onChange(e, o) {
      e.forEach(e => {
        e.intersectionRatio > 0 &&
          (this.loadImage(e.target), o.unobserve(e.target));
      });
    },
    handleImage(el) {
      preloadImage(el.dataset.src).then(src => {
        el.tagName === "IMG" ? (el.src = src) : el.classList.add("fade-in");
        el.removeAttribute("data-src");
      });
    },

    preloadImage(url) {
      return new Promise((resolve, reject) => {
        let image = new Image();
        image.load = resolve(url);
        image.error = reject;
        image.src = url;
      });
    },
    reloadImg() {
      const images = document.querySelectorAll("img[data-src]"),
        config = {
          rootMargin: "0px 0px",
          threshold: 0.01
        };
      let observer;
      "IntersectionObserver" in window
        ? ((observer = new IntersectionObserver(this.onChange, config)),
          images.forEach(e => observer.observe(e)))
        : (console.log("%cIntersection Observers not supported", "color: red"),
          images.forEach(e => this.handleImage(e)));
    }
  }
});
