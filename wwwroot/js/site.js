// BeautyBazaar JavaScript functionality
document.addEventListener('DOMContentLoaded', function () {
    // Initialize tooltips
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    const tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    // Quantity input handlers
    const quantityInputs = document.querySelectorAll('.quantity-input');
    quantityInputs.forEach(input => {
        const decreaseBtn = input.previousElementSibling;
        const increaseBtn = input.nextElementSibling;

        if (decreaseBtn && decreaseBtn.classList.contains('quantity-btn')) {
            decreaseBtn.addEventListener('click', function () {
                let currentValue = parseInt(input.value);
                if (currentValue > 1) {
                    input.value = currentValue - 1;
                }
            });
        }

        if (increaseBtn && increaseBtn.classList.contains('quantity-btn')) {
            increaseBtn.addEventListener('click', function () {
                let currentValue = parseInt(input.value);
                const max = parseInt(input.max) || 999;
                if (currentValue < max) {
                    input.value = currentValue + 1;
                }
            });
        }
    });

    // Add to cart functionality
    document.querySelectorAll('.add-to-cart').forEach(button => {
        button.addEventListener('click', function () {
            const productId = this.getAttribute('data-product-id');
            const quantity = 1; // Default quantity

            // Simple alert for demo
            alert(`Product ${productId} added to cart!`);

            // In a real application, you would make an API call here
            // Example:
            // fetch('/Cart/Add', {
            //     method: 'POST',
            //     headers: {
            //         'Content-Type': 'application/json',
            //     },
            //     body: JSON.stringify({
            //         productId: productId,
            //         quantity: quantity
            //     })
            // })
            // .then(response => response.json())
            // .then(data => {
            //     updateCartBadge(data.cartItemCount);
            // });
        });
    });
});

// Cart management functions
class CartManager {
    static updateCartBadge(count) {
        const cartBadge = document.querySelector('.cart-badge');
        if (cartBadge) {
            cartBadge.textContent = count;
        }
    }

    static showLoading(element) {
        element.innerHTML = '<div class="loading"></div>';
        element.disabled = true;
    }

    static hideLoading(element, originalText) {
        element.innerHTML = originalText;
        element.disabled = false;
    }
}