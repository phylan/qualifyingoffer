<template>
    <v-list-item >
      <v-list-item-title class="primary--text text-md-h5 text-sm-h6">{{ rank }}. {{ player.name }}</v-list-item-title>
      <div class="d-block d-sm-inline">
          <v-list-item-subtitle v-text="formattedSalary" class="text-md-h5 text-sm-h6 secondary--text"></v-list-item-subtitle>
      </div>
    </v-list-item>
</template>

<script>
export default {
    props: {
        player: {
            type: Object
        },
        rank: {
            type: Number
        }
    },
    computed: {
        hasSalaryData() {
            return this.player.salary != null
        },
        formattedSalary() {
            if(!this.hasSalaryData) { return }
            let formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
            return formatter.format(this.player.salary)
        },
    }
}
</script>