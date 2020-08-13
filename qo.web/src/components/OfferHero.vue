<template>
      <div class="z-40">
        <div class="border border-gray-800 bg-gray-800 rounded-t px-10 py-2 text-center">
          <div class="text-3xl sm:text-4xl text-white font-light tracking-wider uppercase">
            2017 Qualifying Offer
          </div>
        </div>
        <div class="shadow-lg border-r border-l border-b border-gray-800 rounded-b bg-white px-10 py-2 text-center h-sm-32">
          <div class="text-4xl sm:text-6xl text-green-700 hidden sm:block" v-show="amount != null">
            {{ formattedAmount }}
          </div>
          <div class="text-4xl sm:text-6xl text-green-700 sm:hidden" v-show="amount != null">
            {{ smallAmount }}
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
      },
      smallAmount() {
        let shortened = this.amount / 1000000
        let rounded = Math.round(shortened * 10) / 10
        return `$${rounded.toFixed(1)} M`
      }
    }
}
</script>