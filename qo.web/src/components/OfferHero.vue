<template>
    <div class="flex flex-col">
      <div class="border border-gray-800 bg-gray-800 rounded-t px-10 py-2 text-center">
        <div class="text-4xl text-white font-light">
          2016 Qualifying Offer
        </div>
      </div>
      <div class="shadow border-r border-l border-b border-gray-800 rounded-b px-10 py-2 text-center">
        <div class="text-6xl text-green-700">
          {{ formattedAmount }}
        </div>
      </div>
    </div>
</template>

<script>
export default {
    props: {
      amount: {
        type: Number
      }
    },
    computed: {
      formattedAmount() {
        let formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
        return formatter.format(this.amount)
      }
    }
}
</script>