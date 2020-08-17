<template>
  <v-card class="px-8 pb-6 pt-4" elevation="4">
      <v-card-title class="mb-n2 font-weight-light text-sm-h4 text-h5 info--text">2017 Qualifying Offer</v-card-title>
      <span class="primary--text text-md-h2 text-sm-h3 text-h4" v-if="amount != null">{{ formattedAmount }}</span>
      <span v-else class="secondary--text font-weight-light text-md-h4 text-sm-h5 text-h6">Loading ...</span>
  </v-card>
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